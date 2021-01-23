     //create delegate       
        public delegate bool nameExistsDelegate(List<string> list, string name);
    
        static Func<string, bool> exists = s =>  return s.Contains(name);
    
        // Create a method for a delegate.
        public static bool IsnameExists(List<string> list, string name)
        {
            return list.Exists(s => exists(s));
        }
    
        // Create a method for a delegate.
        public static string GetName(List<string> list, string name)
        {
            return list.Find(s => exists(s));
        }
