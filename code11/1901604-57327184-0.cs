    var col2 = xlWorkSheet.UsedRange.Columns["I:I", Type.Missing];
    
                foreach (Microsoft.Office.Interop.Excel.Range item in col2.Cells)
                {
                    if (Convert.ToString(item.Value) != null)
                    {
                    Console.WriteLine(Convert.ToString(item.Value));
                    }
                    else
                    {
                      //do something with null
                      return;
                    }
                }
