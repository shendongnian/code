    	void CopyHeaders(object rootTo, NameValueCollection to, NameValueCollection from)
		{
			foreach (string header in from.AllKeys)
			{
				try
				{
					to.Add(header, from[header]);
				}
				catch
				{
					try
					{
						rootTo.GetType().GetProperty(header.Replace("-", "")).SetValue(rootTo, from[header]);
					}
					catch {}
				}
			}
		}
