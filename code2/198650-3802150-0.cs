		public static bool LengthEquals<T>(this IEnumerable<T> en, int length)
		{
			using (var er = en.GetEnumerator())
			{
				for (int i = 0; i < length; i++)
				{
					if (!er.MoveNext())
						return false;
				}
				return !er.MoveNext();
			}
		}
