    public static class MyExtensions
    {
        public static bool TryParse(this Object oObject, string s, out int result)
        {
            return System.Int32.TryParse(s, out result);
        }
    }
