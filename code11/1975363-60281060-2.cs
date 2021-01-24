                   for (var i = 0; i<cols.Count();i++)
                    {
                        if (cols[i].ToString().Trim() == "Column 1")
                        {
                            bulkCopy.ColumnMappings.Add(i, "Column1");
                        }
                        if (cols[i].ToString().Trim() == "Column 2")
                        {
                            bulkCopy.ColumnMappings.Add(i, "Column2");
                        }
                        if (cols[i].ToString().Trim() == "Column 3")
                        {
                            bulkCopy.ColumnMappings.Add(i, "Column3");
                        }
                        //continued for column mappings...
                        
                    }
