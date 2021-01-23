		public static IEnumerable<int> FilterInts(IEnumerable<int> ints)
		{
			var removed = new HashSet<int>();
			foreach (var i in ints)
			{
				var iStr = i.ToString("000000").ToCharArray();
				for (int j = 0; j < iStr.Length; j++)
				{
					var c = iStr[j];
					if (c == '9')
						iStr[j] = '0';
					else
						iStr[j] = (char)(c + 1);
					removed.Add(int.Parse(new string(iStr)));
					iStr[j] = c;
				}
				if (!removed.Contains(i))
					yield return i;
			}
		}
