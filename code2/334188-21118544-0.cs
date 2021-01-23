	public void OrderBy(params int[] columnIndexes)
	{
		_Records.Sort((x, y) =>
		{
			foreach (int i in columnIndexes)
			{
				int result = string.Compare(x[i], y[i]);
				if (result != 0)
					return result;
			}
			return 0;
		});
	}
