    public static class Extensions
    {
        public static DateTime? ToDateTime(this string val)
        {
            DateTime temp;
            if (DateTime.TryParse(val, out temp))
                return temp;
            else 
                return null;
        }
    }
