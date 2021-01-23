    struct BoxData
    {
        Size _bound;
        bool _isFilled; // = false;
        Color _color; // = Color.White;
    
        public Size Bounds
        {
            get
            {
                return _bound;
            }
            set
            {
                _bound = value;
            }
        }
    
        public bool IsFilled
        {
            get
            {
                return _isFilled;
            }
            set
            {
                _isFilled = value;
            }
        }
    
        public Color FillColor
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }
    }
