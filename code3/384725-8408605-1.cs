        // has to implement IEnumerable, so that collection initializer works
        class DynamicDictionary
            : DynamicObject, IEnumerable<KeyValuePair<string, object>>
        {
            public void Add(string name, object value)
            {
                m_dictionary.Add(name, value);
            }
            // IEnumerable implmentation and actual DynamicDictionary code here
        }
        …
        dynamic dict = new DynamicDictionary { { "Id", 42 } };
