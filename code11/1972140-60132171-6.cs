c#
private bool sortOrder = false;
public void SortCol(string propName)
{
	OUModel ou = ADRoot.Descendants().Where(node => node.IsSelected == true).FirstOrDefault() as OUModel;
	if (ou != null)
	{
		if (sortOrder)
			ou.Computers = ou.Computers.OrderBy(GetProperty(propName)).ToList();
		else
			ou.Computers = ou.Computers.OrderByDescending(GetProperty(propName)).ToList();
		sortOrder = !sortOrder;
	}
}
public Func<RemoteComputer, object> GetProperty(string propertyName)
{
	ParameterExpression param = Expression.Parameter(typeof(RemoteComputer), "q");
	MemberExpression member = Expression.PropertyOrField(param, propertyName);
	var body = Expression.Convert(member, typeof(object));
	var property = Expression.Lambda<Func<RemoteComputer, object>>(body, param);
	return property.Compile();
}
 
