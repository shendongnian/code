    for (int rowIndex = workSheet.Dimension.Start.Row; rowIndex <= workSheet.Dimension.End.Row; rowIndex++)
                        {
                            //Assume the first row is the header. Then use the column match ups by name to determine the index.
                            //This will allow you to have the order of the header.Keys change without any affect.
                            var row = workSheet.Cells[string.Format("{0}:{0}", rowIndex)];
                            // check if the row and column cells are empty
                            bool allEmpty = row.All(c => string.IsNullOrWhiteSpace(c.Text));
                            if (allEmpty)
                                continue; // skip this row
                            else{
                                   //here read header
                                   if()
                                     {
                                      //some code
                                     }
                                   else
                                      {
                                       //some code to read body
                                      }
                                }
                        }
