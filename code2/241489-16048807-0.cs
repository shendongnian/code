    class List<T> : System.Collections.Generic.List<T>
		{
			public List(T[] a, int n)
				: base()
			{
					AddRange(a, n);
			}
		}
