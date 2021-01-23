    using System;
    using System.Collections;
    
    namespace MyTest
    {
        public class doTest
        {
            public string getDictType(Object tDict)
            {
                return String.Format("Type : \"{0}\", Count : {1}", ((Hashtable)tDict).GetType().ToString(), ((Hashtable)tDict).Count);
            }
        }
    }
