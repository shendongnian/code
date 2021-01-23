    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Drawing;
    
    
    namespace MyApplication
    { [ Serializable() ]
    
        public class ConfigManager
        {
    
            private int removeDays = 7;
    
            public ConfigManager() { }
    
            public int RemoveDays
            {
                get
                {
                    return removeDays;
                }
                set
                {
                    removeDays = value;
                }
            }
    }
