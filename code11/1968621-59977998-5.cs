    @code {
        IEnumerable<string> myParams = new List<string>()
        {
            "Hello",
            "Whazzzup",
            "Goodbye"
        };
    
        private string _incomingParam;
    
        [Parameter]
        public string incomingParam
        {
            get => _incomingParam;
            set
            {
                _incomingParam = value; // set the default
    
                foreach (var p in myParams)
                {
                    if (String.Equals(p, value, StringComparison.OrdinalIgnoreCase))
                    {
                        _incomingParam = p;
                    }
                }
            }
        }
    }
