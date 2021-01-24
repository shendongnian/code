    var col2 = xlWorkSheet.UsedRange.Columns["I:I", Type.Missing];
    
                foreach (Microsoft.Office.Interop.Excel.Range item in col2.Cells)
                {
                    if (Convert.ToString(item.Value) == null)
                    {
                        //item.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Cyan);
                        item.EntireRow.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Cyan);
    
                    }
    
                    if (Convert.ToString(item.Value) != null)
                    {
                        if (Convert.ToString(item.Value) == "Afterbuild")
                        {
                            item.Value = "Afterbuild";
    
                        }
                        else
                        {
                            if (Convert.ToInt32(item.Value) < 0)
                            {
                               //item.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                                item.EntireRow.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                            }
                        }
                    }
                }
