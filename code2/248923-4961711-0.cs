    public static class SafeConvert
    {
        public static int? ToInt32(string value) 
        {
            int n;
            if (!Int32.TryParse(value, out n))
                return null;
            return n;
        }
    }
