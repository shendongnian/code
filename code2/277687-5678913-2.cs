		public static class MyStructExtension
		{
			public static bool ListsEqual(this IList<MyStruct> a, IList<MyStruct> b)
			{
				if(a==b)
					return true;
				if (a == null || b == null)
					return false;
				if (a.Count != b.Count)
					return false;
				for (int i = 0; i < a.Count; i++)
				{
					if (!a[i].Equals(b[i]))
						return false;
				}
				return true;
			}
		}
