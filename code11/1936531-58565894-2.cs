        public class Key
        {
            private readonly Tuple<int, int> _tuple;
            public Key(int item1, int item2)
            {
                _tuple = new Tuple<int, int>(item1, item2);
            }
            public override bool Equals(object obj)
            {
                if (obj == null)
                {
                    return false;
                }
                if (obj is Key other)
                {
                    return _tuple.Item1 == other.Item1 && _tuple.Item2 == other.Item2;
                }
                return false;
            }
            public override int GetHashCode()
            {
                return _tuple.Item1.GetHashCode() ^ _tuple.Item2.GetHashCode();
            }
            public int Item1 => _tuple.Item1;
            public int Item2 => _tuple.Item2;
        }
		
		...
		
		
		public void Do()
		{
			var map = new Dictionary<Key, int>();
			map.Add(new Key(1, 2), 3);
			map.Add(new Key(1, 2), 4); // will throw System.ArgumentException
		}
