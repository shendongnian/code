	public static int Compare(Version x, Version y)
	{
		int result = x.Major.CompareTo(y.Major);
		if (result != 0)
			return result;
		result = x.Minor.CompareTo(y.Minor);
		if (result != 0)
			return result;
		result = x.Build.CompareTo(y.Build);
		if (result != 0)
			return result;
		result = x.Revision.CompareTo(y.Revision);
        return result;
	}
