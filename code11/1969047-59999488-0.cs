	int size = list.Count;
	if (size == 0)
	{
		return null;
	}
	object first = list[0];
	for (int i = 1; i < size; i++)
	{
		if (list[i] != first)
		{
			throw new NonUniqueResultException(size);
		}
	}
	return first;
