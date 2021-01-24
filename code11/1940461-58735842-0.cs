	public static bool CheckValue(int[] given, int sum)
    {
        if (given == null)
        {
            return false;
        }
        if (given.Length == 0 || given.Length == 1)
        {
            return false;
		}
		
		var hashSet = new HashSet<int>(given);
		
		foreach (int num in given)
		{
			int remainder = sum - num;
			if (remainder != num && hashSet.Contains(remainder))
			{
				return true;
			}
		}
		return false;
    }
