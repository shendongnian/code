        public static StringDemo
        {
           public static bool Contains(this string original, string value, StringComparison comparisionType)
           {
               return original.IndexOf(value, comparisionType) >= 0;
           } 
        }
    
    IEnumerable<MethodInfo> foundMethods = from q in typeof(StringDemo).GetMethods()
                                           where q.Name == "Contains"
                                       select q;
