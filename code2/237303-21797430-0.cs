        public static string[] SplitLeft(this string @this, char[] delimiters, int count)
		{
			var splits = new List<string>();
			int next = -1;
			while (splits.Count + 1 < count && (next = @this.IndexOfAny(delimiters, next + 1)) >= 0)
			{
				splits.Add(@this.Substring(0, next));
				@this = new string(@this.Skip(next).ToArray());
			}
			splits.Add(@this);
			return splits.ToArray();
		}
