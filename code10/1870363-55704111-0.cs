    using System;
    using System.Collections;
    
    namespace CollectionsApplication
    {
        class Program
        {
    	    static void AddElement(IDictionary container, string key, string value)
    	    {
    		    container.Add(key, value);
    	    }
    
            static void Main(string[] args)
            {
                SortedList s1 = new SortedList();
                Hashtable  h1 = new Hashtable();
    
                AddElement(s1, "001", "Zara Ali");
                AddElement(h1, "001", "Zara Ali");
            }
        }
    }
