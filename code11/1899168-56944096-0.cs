	public static int getShortestPath(List<string> nodesToCheck)
	{
		if (!nodesToCheck.Any())
		{
			return -1;
		}
		
		var childrenNodes = new List<string>();
		level++;
		for (int q = 0; q < nodesToCheck.Count; q++)
		{
			string[] options = bookFormat[Convert.ToInt32(nodesToCheck[q])-1].Split(' ');                
			if (options[0] == "0")
			{
				return level;
			}
			else
			{
				for (int t = 1; t < options.Length; t++)
				{
					if (!alreadyChecked.Contains(options[t]))
					{
						childrenNodes.Add(options[t]);
						alreadyChecked.Add(nodesToCheck[q]);
					}
				}
			}
			nodesToCheck.Clear();
		}
		return getShortestPath(childrenNodes);
	}
	
