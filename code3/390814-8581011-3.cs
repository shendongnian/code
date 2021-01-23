           private string _name;
           public string name
           {
                get { return _name; }
                set
                {
                    if (value != _name)
                    {
                        _name = value;
                        hi(_name); 
                    }
                }
            }
