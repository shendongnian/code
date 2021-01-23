        using System;
        using System.Linq;
        using System.Text;
        using System.Collections.Generic;
    
        namespace NetworkSwitcher
        {
    
            [Serializable()]
            public class testClass
            {
                private string str;
    
                public string _str
                {
                    get { return str; }
                    set { str = value; }
                }
    
                public testClass()
                {
                    //Default
                }
            } 
        }
