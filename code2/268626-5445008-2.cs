    public sealed class InfoStrings
    {
        private InfoStrings()
        {
        }
    
        public static InfoStrings Instance 
        { 
            get { return Nested.instance; } 
        }
            
        private class Nested
        {
            static Nested()
            {
            }
            internal static readonly InfoStrings instance = new InfoStrings();
        }
    }
