    var fileName = @"D:\Pavan\WorkDiployed.xlsx";
          var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0; data source={0}; Extended Properties=Excel 12.0;", fileName);
          OleDbConnection con = new System.Data.OleDb.OleDbConnection(connectionString);
          OleDbDataAdapter cmd = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", con);
          con.Open();
          System.Data.DataSet excelDataSet = new DataSet();
          cmd.Fill(excelDataSet);
          DataTable data = excelDataSet.Tables[0];
          DataRow[] arrdata = data.Select();
          foreach (DataRow rw in arrdata)
          {
              object[] cval = rw.ItemArray;
          }           
            
          con.Close();
          MessageBox.Show (excelDataSet.Tables[0].ToString ()); 
