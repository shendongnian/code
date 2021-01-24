        private string _location;
        public string Location
        {
            get { return _location; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _location = "US";
                }
                else
                {
                    _location = value;
                }
            }
        }
