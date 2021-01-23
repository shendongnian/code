    public int Compare(object x, object y)
	{
		IComparable propX = (IComparable)mSortingProperty.GetValue(x, null);
		IComparable propY = (IComparable)mSortingProperty.GetValue(y, null);
		int compare;
		if ((compare = propX.CompareTo(propY)) == 0) {
			if (x.GetHashCode() < y.GetHashCode())
				return (-1);
			else if (x.GetHashCode() > y.GetHashCode())
				return (+1);
			else return (0);
		} else
			return (compare);
	}
