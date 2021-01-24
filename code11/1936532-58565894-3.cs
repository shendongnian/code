        public class TupleIntIntEqualityComparer : IEqualityComparer<Tuple<int, int>>
        {
            bool IEqualityComparer<Tuple<int, int>>.Equals(Tuple<int, int> x, Tuple<int, int> y)
            {
                if (x == null || y == null)
                {
                    return false;
                }
                return x.Item1 == y.Item1 && x.Item2 == y.Item2;
            }
            int IEqualityComparer<Tuple<int, int>>.GetHashCode(Tuple<int, int> obj)
            {
                return obj.Item1.GetHashCode() ^ obj.Item2.GetHashCode();
            }
        }
		
		...
		
		public void Do()
		{
            var map = new Dictionary<Tuple<int, int>, int>(new TupleIntIntEqualityComparer());
            map.Add(new Tuple<int, int>(1, 2), 3);
            map.Add(new Tuple<int, int>(1, 2), 4); // will throw System.ArgumentException
		}
