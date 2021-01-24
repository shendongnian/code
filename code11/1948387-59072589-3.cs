                ((Excel.Range)worksheet.Cells[rowNumber, 7]).Value = message;
                Range cell = (Excel.Range)worksheet.Cells[rowNumber, 7];
    
                if (colorType.Equals("Green"))
                {
                    cell.Characters[0, message.Length].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                }
                else
                {
                    cell.Characters[0, message.Length].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                }
           
