            public Boolean InvalidColumnNames()
            {
                bool errorInFile = false;
                using (ReadAndStreamFile())
                {
                    reader.Read();
                    {
                        int counter = 0;
                        var ColumnsNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetValue(i)).ToList();
                        if (ColumnsNames.Count != 0 && reader.Read() == true)
                        {
                            for (int columnNumber = 0; columnNumber < ColumnsNames.Count; columnNumber++)
                            {
                                var excel = new ExcelDataReaderFile();
                                var cellAddress = excel.GetAddress(counter, 0);
                                counter += 1;
                                if (ColumnsNames[columnNumber] != null && ColumnsNames[columnNumber].ToString().Length > columnNameSizeLimit)
                                {
                                    Console.WriteLine($"[{GetFileName(file)}]{reader.Name}!{cellAddress} is {columnNumber.ToString().Length} characters long and exceeds {columnNameSizeLimit} character column name limit. Supply a valid column name.");
                                    errorInFile =  true;
                                }
                                else if (ColumnsNames[columnNumber] == null)
                                {
                                    Conseol.WriteLine($"[{GetFileName(file)}]{reader.Name}!{cellAddress} is empty. Supply a valid column name.");
                                    errorInFile =  true;
                                }
                                else
                                {
                                    // return true;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine($"[{GetFileName(file)}]{reader.Name} is empty and cannot be validated. Supply a non-empty file.");
                            errorInFile =  true;
                        };
                    }
                    reader.Dispose();
                    reader.Close();
    
                    return errorInFile;
                }
            }
