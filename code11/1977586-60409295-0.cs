    //find last cell if needed
                int lastCell = xlWorkSheet.Cells.Find(
                    "*",
                    System.Reflection.Missing.Value,
                    Excel.XlFindLookIn.xlValues,
                    Excel.XlLookAt.xlWhole,
                    Excel.XlSearchOrder.xlByRows,
                    Excel.XlSearchDirection.xlPrevious,
                    false,
                    System.Reflection.Missing.Value,
                    System.Reflection.Missing.Value).Row;
                Excel.Range rangeCheck = xlWorkSheet.Range["A1:A" + lastCell];
    
                foreach (Excel.Range cell in rangeCheck.Cells)
                {
                    string checkStrigng = Convert.ToString(cell.Value);//converts cell value to string for comparision
                    if (checkString == textbox.Text)
                    {
                        cell.Interior.Color = System.Drawing.Color.Yellow;
                    }
                }
