        class StringCollection : System.Collections.IList {
            private List<object> impl = new List<object>();
            public int Add(object value) {
                Console.Beep();
                impl.Add(value);
                return Count;
            }
            public void Clear() {
                impl.Clear();
            }
            
            // etc...
        }
