    private string _name
    
     public string name
            {
                get { return _name; }
                set
                {
                    // won't crash any more
                    if (value != _name)
                    {
                        _name = value;
                        hi(name); 
                    }
                }
            }
