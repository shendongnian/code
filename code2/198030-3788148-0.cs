    public static class Append
    {
        ....
        private static StringBuilder _sb = new StringBuilder();
        public static StringBuilder sb { 
            get { return _sb; } 
            set { 
                _sb = value; 
            }
        }
        ....
    }
