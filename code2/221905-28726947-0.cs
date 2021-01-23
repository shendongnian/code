    public static string CellGetStringValue(this WorksheetBase theSheet, int row, int column)
    {
        var result = string.Empty;
    
        if (theSheet != null)
        {
            var rng = theSheet.Cells[row, column] as Excel.Range;
                    
            if (rng != null)
                result = (string) rng.Text;
        }
    
        return result;
    }
