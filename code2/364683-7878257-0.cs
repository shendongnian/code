	public dynamic Traverse(dynamic entity, Func<dynamic, bool> conditions, Action<dynamic> method)
	{
		foreach (var propInfo in GetTraversableProperties(entity))
		{
			if (conditions) method(propInfo.GetValue(etc));
			Traverse(propInfo, conditions, method);
		}
		return entity;
	}
