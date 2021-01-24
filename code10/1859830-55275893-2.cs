                DataTable dt_1sttxtfile = ConvertToDataTable(@"C:\Users\manchunl\Desktop\1sttxtfile.txt", 10);
                DataTable dt_2ndtxtfile = ConvertToDataTable(@"C:\Users\manchunl\Desktop\2ndtxtfile.txt", 10);
                Dictionary<string, string> reference_File = new Dictionary<string, string>() { { "1", "AAA" }, { "2", "BBB" }, { "3", "CCC" } };
                int columnCount = dt_1sttxtfile.Columns.Count;
                foreach (DataRow row1 in dt_1sttxtfile.Rows)
                {
                    foreach (DataRow row2 in dt_2ndtxtfile.Rows)
                    {
                        for (int column = 0; column < columnCount; column++)
                        {
                            if (reference_File.TryGetValue(row1[column].ToString(), out var referenceValue))
                            {
                                if (string.Compare(referenceValue, row2[column].ToString(), StringComparison.InvariantCulture) == 0)
                                {
                                    // perform your task
                                }
                            }
                        }
                    }
                }
