	using (OpenFileDialog openFileFromDialog = new OpenFileDialog())
            {
                openFileFromDialog.Filter = "Excel Document|*.xls";
                openFileFromDialog.Title = "Select FIle";
                openFileFromDialog.ShowDialog();
                if (String.IsNullOrEmpty(openFileFromDialog.FileName))
                    return;
                using (OleDbConnection connection = new OleDbConnection { ConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0; 
							Data Source={0};Extended Properties=Excel 12.0;", openFileFromDialog.FileName) })
                {
                        using (DbCommand command = connection.CreateCommand())
                        {
                            command.CommandText = String.Format("SELECT * FROM [{0}]", sheetName);
                            if (connection.State == ConnectionState.Closed)
                            {
                                connection.Open();
                            }
                            using (DbDataReader dr = command.ExecuteReader())
                            {
                                
                                while (dr.Read())
                                {
                                    
                                    object[] row = new object[]
                                            { 
                                            dr[1],
						                    dr[2],
						                    dr[3]
						                    };
                                    YOURDATATABLE.Rows.Add(row);
                                    }
                            }
                        }
                	  }
           		}
