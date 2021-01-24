    void Main()
    {
      Stopwatch sw = new Stopwatch();
      sw.Start();
      string sqlConnectionString = @"server=.\SQLExpress2012;Trusted_Connection=yes;Database=SampleDb";
    
      string path = @"d:\temp\SampleTextFiles";
      string fileName = @"combDoubledX.csv";
      
      using (OleDbConnection cn = new OleDbConnection(
    	"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+path+
    	";Extended Properties=\"text;HDR=No;FMT=Delimited\";"))
      
      using (SqlConnection scn = new SqlConnection( sqlConnectionString ))
      {
      OleDbCommand cmd = new OleDbCommand("select * from "+fileName, cn);
      
      SqlBulkCopy sbc = new SqlBulkCopy(scn, SqlBulkCopyOptions.TableLock,null);
      
      sbc.ColumnMappings.Add(0,"[Category]");
      sbc.ColumnMappings.Add(1,"[Activity]");
      sbc.ColumnMappings.Add(5,"[PersonId]");
      sbc.ColumnMappings.Add(6,"[FirstName]");
      sbc.ColumnMappings.Add(7,"[MidName]");
      sbc.ColumnMappings.Add(8,"[LastName]");
      sbc.ColumnMappings.Add(12,"[Email]");
    
      cn.Open();
      scn.Open();
      
      SqlCommand createTemp = new SqlCommand();
      createTemp.CommandText = @"if exists
       (SELECT * FROM tempdb.sys.objects 
       WHERE object_id = OBJECT_ID(N'[tempdb]..[##PersonData]','U'))
       BEGIN
    		drop table [##PersonData];
       END
       
      create table ##PersonData 
      (
        [Id] int identity primary key,
        [Category] varchar(50), 
        [Activity] varchar(50) default 'NullOlmasin', 
        [PersonId] varchar(50), 
        [FirstName] varchar(50), 
        [MidName] varchar(50), 
        [LastName] varchar(50), 
        [Email] varchar(50)
      )
    "; 
      createTemp.Connection = scn;
      createTemp.ExecuteNonQuery();
     
      OleDbDataReader rdr = cmd.ExecuteReader();
      
      sbc.NotifyAfter = 200000;
      //sbc.BatchSize = 1000;
      sbc.BulkCopyTimeout = 10000;
      sbc.DestinationTableName = "##PersonData";
      //sbc.EnableStreaming = true;
      
      sbc.SqlRowsCopied += (sender,e) =>
        {
        Console.WriteLine("-- Copied {0} rows to {1}.[{2} milliseconds]", 
          e.RowsCopied, 
          ((SqlBulkCopy)sender).DestinationTableName,
          sw.ElapsedMilliseconds);
        };
      
      sbc.WriteToServer(rdr);
    
      if (!rdr.IsClosed) { rdr.Close(); }
      
      cn.Close();
      scn.Close();
      }
      sw.Stop();
      sw.Dump();
    }
