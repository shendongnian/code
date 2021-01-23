    public static string GetCellValue(string letter0) {
        var line = Convert.ToInt32(letter0.Substring(1, 2));
        var column = Convert.ToInt32(letter0[0] - 'A' + 1);
        var result = (line - 1) * 8 + column;
        return Convert.ToString(result);
    }
    ...
    
    Cells[rownum, 2].Value = GetCellValue(letter0);         
