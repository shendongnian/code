        public class EnumList<TEnum> where TEnum:struct, IComparable
        {
            private IList<TEnum> _list;
            public EnumList()
            {
                _list = new List<TEnum>();
            }
            public void Add(TEnum val)
            {
                _list.Add(val);
            }
            public TEnum Get(TEnum val)
            {
                return _list.Single(l => l.CompareTo(val) == 0);
            }
        }
        public class MyClass
        {
            public void MyMethod()
            {
                var list = new EnumList<DayOfWeek>();
                var value = (int)list.Get(DayOfWeek.Wednesday);
            }
        }
