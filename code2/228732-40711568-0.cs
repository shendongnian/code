    public struct Foostruct
    {
        private int? _x;
        private int? _y;
    
        public int X
        {
            get { return _x ?? 20; } // replace 20 with desired default value
            set { _x = value; }
        }
    
        public int Y
        {
            get { return _y ?? 10; } // replace 10 with desired default value
            set { _y = value; }
        }
    }
