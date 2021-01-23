    public int[] MyFunc(DataTable dt, int[] array)
    {
		Dictionary<int, int> allowedsIds = new Dictionary<int, int>();
		Fill your dictionary with ids you want to keep
		int[] newArray = new int[inputArray.Length];
		int newArrayCount = 0;
		for (int i = 0; i < inputArray.Length; ++i)
		{
			if (allowedsIds.Contains(inputArray[i]))
			{
				newArray[newArrayCount++] = inputArray[i];
			}
		}
		Array.Resize(newArray, newArrayCount);
    }
