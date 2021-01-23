        static class PhpListTest
        {
            public static void Test()
            {
                string a = null, b = null, c = null;
    
                new ValList(v => a = v,
                            v => b = v,
                            v => c = v).SetFrom(new string[] { "foo", "bar" });
                //here a is "foo", b will be "bar", and c is still null
            }
        }
    
        class ValList
        {
            private Action<string>[] _setters;
    
            public ValList(params Action<string>[] refs)
            {
                _setters = refs;
            }
    
            internal void SetFrom(string[] values)
            {
                for (int i = 0; i < values.Length && i < _setters.Length; i++)
                    _setters[i](values[i]);
            }
        }
