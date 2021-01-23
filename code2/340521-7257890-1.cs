	private void RemoveDuplicates(ref List<string> list_lines, ref int Duplicate_Count)
	{
	    Duplicate_Count = 0;
		List<string> list_lines2 = new List<string>();
		HashSet<string> hash = new HashSet<string>();
		
		foreach (string line in list_lines)
		{
			string[] split = line.Split('|');
			string firstPart = split.Length > 0 ? split[0] : string.Empty;
			
			if (hash.Add(firstPart)) 
			{
				list_lines2.Add(line);
			}
			else
			{
			    Duplicate_Count++;
			}
		}
		
		list_lines = list_lines2;
	}
