    public static class TE
    {
        public static int StringToInt(this string x)
        {
            int result;
            return int.TryParse(x, out result) ? result : 0;
        }
    }
