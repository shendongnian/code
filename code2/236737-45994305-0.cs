    using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                //Build the CSV file data as a Comma separated string.
                                string csv = string.Empty;
                                foreach (DataColumn column in dt.Columns)
                                {
                                    //Add the Header row for CSV file.
                                    csv += column.ColumnName + ',';
                                }
                                //Add new line.
                                csv += "\r\n";
                                foreach (DataRow row in dt.Rows)
                                {
                                    foreach (DataColumn column in dt.Columns)
                                    {
                                        //Add the Data rows.
                                        csv += row[column.ColumnName].ToString().Replace(",", ";") + ',';
                                    }
                                    //Add new line.
                                    csv += "\r\n";
                                 }
                                 //Download the CSV file.
                                 Response.Clear();
                                 Response.Buffer = true;
                                 Response.AddHeader("content-disposition", "attachment;filename=SqlExport"+DateTime.Now+".csv");
                                 Response.Charset = "";
                                 //Response.ContentType = "application/text";
                                 Response.ContentType = "application/x-msexcel";
                                 Response.Output.Write(csv);
                                 Response.Flush();
                                 Response.End();
                               }
