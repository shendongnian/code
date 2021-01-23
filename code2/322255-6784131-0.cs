		public static string ReplaceTokens(string value, NameValueCollection tokens)
		{
			if (tokens == null || tokens.Count == 0 || string.IsNullOrEmpty(value)) return value;
			string token = null;
			foreach (string key in tokens.Keys)
			{
				token = "{" + key + "}";
				value = value.Replace(token, tokens[key]);
			}
			return value;
		}
