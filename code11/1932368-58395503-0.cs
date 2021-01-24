        public void ConvertToCSV(string sourceFile, string targetFile)
                {
                    using (var stream = System.IO.File.Open(sourceFile, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    {
                        //add ExcelDataReader and ExcelDataReader.DataSet
                        //Reading from a OpenXml Excel file (2007 format; *.xlsx)
                        using (var reader = ExcelDataReader.ExcelReaderFactory.CreateOpenXmlReader(stream))
                        {
                            //DataSet result = reader.AsDataSet();
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });
                            if (result.Tables.Count > 0)
                            {
                                    System.Text.StringBuilder output = new StringBuilder();
                                DataTable table = result.Tables[0];
                                //save column names
                                output.AppendLine(String.Join(",", table.Columns.Cast<System.Data.DataColumn>().ToList()));
                                //save all rows
                                foreach (System.Data.DataRow dr in table.Rows)
                                {
                                    output.AppendLine(String.Join(",", dr.ItemArray.Select(f=>f.ToString() ).ToList()   ) );
                                }
                                System.IO.File.WriteAllText(targetFile, output.ToString());
                            }
                        }
                    }
                }
