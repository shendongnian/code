		public void Do()
		{
            var map = new Dictionary<Tuple<int, int>, int>();
            map.Add(new Tuple<int, int>(1, 2), 3);
            map.Add(new Tuple<int, int>(1, 2), 4); // will throw System.ArgumentException
		}
