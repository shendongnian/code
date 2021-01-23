    this.conn = new oleDbConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
    OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM name", conn);
    DataSet ds = new DataSet();
    adapter.Fill(ds, "name");
    DataTable data = ds.Tables["name"];
    sqlCommand = "CREATE TABLE ##TempTable(Name, DOB, Location)";
    SqlConnection SQLconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);
    SQLconn.Open();
    using (SqlCommand cmd = new SqlCommand(sqlCommand, SQLconn))
    {
        cmd.CommandType = CommandType.Text;
        cmd.ExecuteReader();
        SqlBulkCopy bulkCopy = new SqlBulkCopy(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
        // Map the columns
        foreach (DataColumn col in data.Columns)
        bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
        bulkCopy.DestinationTableName = "##TempTable";
        bulkCopy.WriteToServer(data);
    }
    string MergeCommand = string.Concat("insert into [Existing Table] (Name, DOB, Location) ",
        "select distinct Name, DOB, Location from ##TempTable ",
        "WHERE NOT EXISTS (SELECT 1 FROM [Existing Table] a WHERE a.[Name] = ##TempTable.[Name] and a.[DOB] = ##TempTable.[DOB])");
    SqlConnection Mergeconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
    Mergeconn.Open();
    using (SqlCommand MergeCmd = new SqlCommand(MergeCommand, Mergeconn))
    {
        MergeCmd.CommandType = CommandType.Text;
        MergeCmd.ExecuteReader();
    }
    SQLconn.Close();
    Mergeconn.Close();
