    public static DateTime? GetFieldAsDateTime(int y, int m, int d, 
        int h, int mi, int s)
    {
        DateTime result;
        var input = 
            string.Format("{0:000#}-{1:0#}-{2:0#}T{3:0#}:{4:0#}:{5:0#}", 
            y, m, d, h, mi, s);
    
        if (DateTime.TryParse(input, CultureInfo.InvariantCulture, 
            System.Globalization.DateTimeStyles.RoundtripKind, out result))
        {
            return result;
        }
    
        return null;
    }
