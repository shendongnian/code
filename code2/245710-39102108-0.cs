            try
            {
                foreach (DataTable DDT in _DataSet.Tables)
                {
                    String MyFile = @DestinationCsvDirectory + "\\_" + DDT.TableName.ToString() + DateTime.Now.ToString("yyyyMMddhhMMssffff") + ".csv";//+ DateTime.Now.ToString("ddMMyyyyhhMMssffff")
                    using (var outputFile = File.CreateText(MyFile))
                    {
                        String CsvText = string.Empty;
                        foreach (DataColumn DC in DDT.Columns)
                        {
                            if (CsvText != "")
                                CsvText = CsvText + "," + DC.ColumnName.ToString();
                            else
                                CsvText = DC.ColumnName.ToString();
                        }
                        outputFile.WriteLine(CsvText.ToString().TrimEnd(','));
                        CsvText = string.Empty;
                        foreach (DataRow DDR in DDT.Rows)
                        {
                            foreach (DataColumn DCC in DDT.Columns)
                            {
                                if (CsvText != "")
                                    CsvText = CsvText + "," + DDR[DCC.ColumnName.ToString()].ToString();
                                else
                                    CsvText = DDR[DCC.ColumnName.ToString()].ToString();
                            }
                            outputFile.WriteLine(CsvText.ToString().TrimEnd(','));
                            CsvText = string.Empty;
                        }
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }  
        }
