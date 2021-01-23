        bool exist = List.Init(6, 8, 2, 9, 12).Contains(8);
        foreach (int i in List.Init(6, 8, 2, 9, 12))
        {
            Console.WriteLine(i.ToString());
        }
        public class List : IEnumerable<int>
        {
            private int[] _values;
            public List(params int[] values)
            {
                _values = values;
            }
            public static List Init(params int[] values)
            {
                return new List(values);
            }
            public IEnumerator<int> GetEnumerator()
            {
                foreach (int value in _values)
                {
                    yield return value;
                }
            }
            public bool Contains(int value)
            {
                return Array.IndexOf(_values, value) > -1;
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
