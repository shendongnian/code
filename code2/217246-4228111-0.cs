    	public static string FindDuplicateSubstring(string s)
		{
			for (int len = s.Length-1; len > 0; len--) {
				var dict = new Dictionary<string, int>();
				for (int i = 0; i <= s.Length - len; i++) {
					string sub = s.Substring(i, len);
					if (dict.ContainsKey(sub)) return sub;
					else dict[sub] = i;
				}
			}
			return null;
		}
