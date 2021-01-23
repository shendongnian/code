    using System;
    
    namespace ExternalAssembly
    {
        public enum Options
        {
            OptionNumberOne,
            OptionNumberTwo,
        }
        public class Helper
        {
            public string DoSomething(Options option)
            {
                // really do something useful here
                return String.Empty;
            }
        }
    }
