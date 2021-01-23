        class DynamicDictionary : DynamicObject
        {
            private readonly IDictionary<string, object> m_expandoObject =
                new ExpandoObject();
            public dynamic Values
            {
                get { return m_expandoObject; }
            }
            // DynamicDictionary implementation that uses m_expandoObject here
        }
        …
        dynamic dict = new DynamicDictionary { Values = { Id = 42 } };
