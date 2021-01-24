    var col2 = xlWorkSheet.UsedRange.Columns["I:I", Type.Missing];
    
                foreach (Microsoft.Office.Interop.Excel.Range item in col2.Cells)
                {
                    if (Convert.ToString(item.Value) == null)
                    {
                        //Change interior color for full row
                        item.EntireRow.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Cyan);
                    }
                    else
                    {
                        MessageBox.Show("Empty cell");
                    }
                }
