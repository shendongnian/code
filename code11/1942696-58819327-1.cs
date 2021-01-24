    private void AddValue(int i, Excel.Worksheet workSheet, DataTable dtAltTag, int Row)
            {
                //Header Working starts here
                string[] columName = new string[] { "column1", "column2", "column2", "column2", "column2" }; //add header as per you requirement
                if (Row == 0)
                {
                    for (int c = 0; c < columName.Length; c++)
                    {
                        workSheet.Cells[0, c] = new Excel.Cell(columName[c]);
                    }
                }
                                  
                //add data
                for (int c = 0; c < columName.Length; c++)
                {
                    workSheet.Cells[Row + 1, c] = new Excel.Cell(dtAltTag.Rows[i].ItemArray[c].ToString());            
                }
              
    
            }
