    public static bool TryIsPropertyNull(this object obj, string PropName, out bool isNull)
	{
		isNull = false;
		var prop = obj.GetType().GetProperty(PropName);
		if (prop == null)
			return false;
		isNull = prop.GetValue(obj) == null;
		return true;
	}
