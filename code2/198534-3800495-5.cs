		static List<string> SplitByComma(string str)
		{
			bool quoted = false;
			bool attr = false;
			int start = 0;
			var result = new List<string>();
			for(int i = 0; i < str.Length; ++i)
			{
				switch(str[i])
				{
					case '[':
						if(!quoted) attr = true;
						break;
					case ']':
						if(!quoted) attr = false;
						break;
					case '\"':
						if(!attr) quoted = !quoted;
						break;
					case ',':
						if(!quoted && !attr)
						{
							result.Add(str.Substring(start, i - start));
							start = i + 1;
						}
						break;
				}
			}
			if(start < str.Length)
				result.Add(str.Substring(start));
			return result;
		}
