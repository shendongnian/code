    static List<string> SplitLine(string str)
    		{
    			var lines = new List<string>();
    
    			for (int i = 0; i < str.Length; i++)
    			{
    				if (!char.IsDigit(str[i]))
    				{
    					lines.Add(str[i].ToString());
    					continue;
    				}
    				string digit = "";
    				while (char.IsDigit(str[i]))
    				{
    					digit += str[i++];
    				}
    				i--;
    				lines.Add(digit);
    			}
    
    			return lines;
    		}
