		public class MyEqualityComparer : IEqualityComparer<Foo>
		{
			public bool Equals(Foo x, Foo y)
			{
				return x.Id == y.Id;
			}
			public int GetHashCode(Foo obj)
			{
				return obj.Id.GetHashCode();
			}
		}
      var result = list1.Intersect(list2, new MyEqualityComparer()).ToList();
