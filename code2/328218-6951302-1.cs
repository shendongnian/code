	public bool Remove(T item)
	{
		int index = this.IndexOf(item);
		if (index >= 0x0)
		{
			this.RemoveAt(index);
			return true;
		}
		return false;
	}
