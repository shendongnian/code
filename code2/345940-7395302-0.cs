    public static class Cleaner
    {
        public static string Clean(this string s)
        {
            return s.Replace("'", " "); 
        }
        public static void Clean(ref string s1)
        {
            s1 = s1.Clean();
        }
        public static void Clean(ref string s1, ref string s2)
        {
            s1 = s1.Clean();
            s2 = s2.Clean();
        }
        public static void Clean(ref string s1, ref string s2, ref string s3)
        {
            s1 = s1.Clean();
            s2 = s2.Clean();
            s3 = s3.Clean();
        }
        // etc ad nauseum...
    }
    {
        string a = ...;
        string b = ...;
        string c = ...;
    
        Cleaner.Clean(ref a, ref b, ref c)
    }
