public void Main()
		{
            // TODO: Add your code here
            string datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
            try
            {
                //Declare Variables
                string FileNamePart = Dts.Variables["User::FlatFileNamePart"].Value.ToString();
                string DestinationFolder = Dts.Variables["User::DestinationFolder"].Value.ToString();
                string StoredProcedureFig1_1 = Dts.Variables["User::StoredProcedureFig1_1"].Value.ToString();
                string StoredProcedureFig1_2 = Dts.Variables["User::StoredProcedureFig1_2"].Value.ToString();
                string FileDelimiter = Dts.Variables["User::FileDelimiter"].Value.ToString();
                string FileExtension = Dts.Variables["User::FileExtension"].Value.ToString();
                //USE ADO.NET Connection from SSIS Package to get data from table
                SqlConnection myADONETConnection = new SqlConnection();
                myADONETConnection = (SqlConnection)(Dts.Connections["localhost.onramps_tacc"].AcquireConnection(Dts.Transaction)
                    as SqlConnection);
                //Execute Stored Procedure and save results in data table
                string query1 = "EXEC " + StoredProcedureFig1_1;
                string query2 = "EXEC " + StoredProcedureFig1_2;
                SqlCommand cmd1 = new SqlCommand(query1, myADONETConnection);
                SqlCommand cmd2 = new SqlCommand(query2, myADONETConnection);
                DataSet dset = new DataSet();
                DataTable d_table1 = dset.Tables.Add("Fig1_1");
                DataTable d_table2 = dset.Tables.Add("Fig1_2");
                d_table1.Load(cmd1.ExecuteReader());
                d_table2.Load(cmd2.ExecuteReader());
                myADONETConnection.Close();
                foreach (DataTable table in dset.Tables)
                {
                    string FileFullPath = DestinationFolder + "\\" + FileNamePart + "_" + table + datetime + FileExtension;
                    StreamWriter sw = null;
                    sw = new StreamWriter(FileFullPath, false);
                    // Write the Header Row to File
                    int ColumnCount = table.Columns.Count;
                    for (int ic = 0; ic < ColumnCount; ic++)
                    {
                        sw.Write(table.Columns[ic]);
                        if (ic < ColumnCount - 1)
                        {
                            sw.Write(FileDelimiter);
                           
                        }
                    }
                    sw.Write(sw.NewLine);
                    // Write All Rows to the File
                    foreach (DataRow dr in table.Rows)
                    {
                        for (int ir = 0; ir < ColumnCount; ir++)
                        {
                            if (!Convert.IsDBNull(dr[ir]))
                            {
                                sw.Write(dr[ir].ToString());
                              
                            }
                            if (ir < ColumnCount - 1)
                            {
                                sw.Write(FileDelimiter);
                               
                            }
                        }
                        sw.Write(sw.NewLine);
                      
                    }
                    sw.Close();
                    Dts.TaskResult = (int)ScriptResults.Success;
                }
            }
