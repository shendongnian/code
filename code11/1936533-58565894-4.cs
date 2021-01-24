        public class Key
        {
            public Key(int item1, int item2)
            {
                Tuple = new Tuple<int, int>(item1, item2);
            }
            public override bool Equals(object obj)
            {
                if (obj == null)
                {
                    return false;
                }
                if (obj is Key other)
                {
                    return Tuple.Equals(other.Tuple);
                }
                return false;
            }
            public override int GetHashCode()
            {
                return Tuple.GetHashCode();
            }
            public Tuple<int, int> Tuple { get; private set; }
        }
		
		public void Do()
		{
			var map = new Dictionary<Key, int>();
			map.Add(new Key(1, 2), 3);
			map.Add(new Key(1, 2), 4); // will throw System.ArgumentException
		}
