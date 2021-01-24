                    if (filename.EndsWith(".xls"))
                    {
                        connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", pathToExcelFile);
                    }
                    else if (filename.EndsWith(".xlsx"))
                    {
                        connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + pathToExcelFile + "';Extended Properties=\"Excel 12.0;HDR=YES;\"";
                    }
