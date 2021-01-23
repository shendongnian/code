    public static class RefData
    {
        public static Dictionary<int, string> dict = new Dictionary<int, string>();
        static Refdata() //this could also be: public static void PopulateDictionary()
        {
            dict.Add(0, "This Text");
            dict.Add(3, "That Text");
            dict.Add(4, "More Text"); 
        }
    }
