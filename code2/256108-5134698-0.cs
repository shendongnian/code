    // Properties
        private string _text
        public string text
        {
            get
            {
                return _text;
            }
            set
            {
                if(value != null)
                    _text = value;
                else
                    _text = "";
            }
        }
