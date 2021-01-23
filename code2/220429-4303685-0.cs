	public static List<string> SplitBy(string[] data, string splitStr)
	{
		var res = new List<string>();
		bool passedSplitStr = false;
		var sb = new StringBuilder();
		for(int i = 0; i < data.Length; ++i)
		{
			if(data[i] == splitStr)
			{
				if(!passedSplitStr)
				{
					passedSplitStr = true;
				}
				else
				{
					res.Add(sb.ToString());
					sb.Clear();
				}
				sb.Append(data[i]);
			}
			else
			{
				if(passedSplitStr)
					sb.Append(data[i]);
			}
		}
		if(sb.Length != 0)
			res.Add(sb.ToString());
		return res;
	}
