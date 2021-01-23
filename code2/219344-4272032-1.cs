    class MyClass
    {
        private ObjectDict m_dict;
    
        public string Recurse(string pattern, ObjectDict dict)
        {
            m_dict = dict;
            return HelperRecurse(pattern);
        }
    
        private string HelperRecurse(string pattern) 
        {
            // do some work. (referring to m_dict)
            HelperRecurse(pattern);  // Go recursive
    
            return "Hello World";
        }
    }
