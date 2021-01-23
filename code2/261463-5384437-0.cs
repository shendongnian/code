    public Dictionary<string, object> Dictionary
            {
                get
                {
                    if (_dictionary == null)
                        _dictionary = new Dictionary<string, object>();
                    return _dictionary;
                }
                set
                {
                    Dictionary = value;
                }
            }
