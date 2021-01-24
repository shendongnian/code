    using (SqlConnection sqlCon = new SqlConnection("Data Source=" + GetEnvironmentVariable.MachineName + "; Initial Catalog=" + databaseName + "; User ID=" + DBUser + "; Password=" + DBUserPassword + ";"))
      {
          SqlCommand command = new SqlCommand(sqlQuery, sqlCon);
          sqlCon.Open();
          SqlDataAdapter da = new SqlDataAdapter();
          da.SelectCommand = cmd; 
          DataTable dt = new DataTable(); 
          da.fill(dt);
          try
          {
             if(dt != null && dt.Rows.Count > 0)
             {
                string columnName = dt.Columns[0].ToString();
                DataRow dr = dt.Rows[0];
             }
          }
          catch (Exception ex)
          {
              logger.Debug(ex, "Writing Database Output to the text file failed");
          }
          finally
          {
              reader.Close();
              outputFile.Close();
          }     
       }
