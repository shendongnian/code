		public string DoExtendedTransferAsString(string operation, NameValueCollection query, FormatCollection formats)
		{
			foreach (string key in query.Keys)
			{
				query[key] = HttpUtility.HtmlEncode(query[key]);
			}
			System.Net.WebClient client = new System.Net.WebClient();
			client.QueryString = query;
			client.QueryString["op"] = operation;
			client.QueryString["session"] = SessionId;
			using (Stream stream = client.OpenRead(url))
			{
				FormatCollection formats = new FormatCollection(stream);
			}
			return formats;
		}
