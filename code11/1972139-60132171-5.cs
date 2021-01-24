c#
private bool sortOrder = false;
public void SortCol<T>(Expression<Func<RemoteComputer,T>> property)
{
	OUModel ou = ADRoot.Descendants().Where(node => node.IsSelected == true).FirstOrDefault() as OUModel;
	if (ou != null)
	{
		if (sortOrder)
		{
			ou.Computers = ou.Computers.AsQueryable().OrderBy(property).ToList();
		}
		else
		{
			ou.Computers = ou.Computers.AsQueryable().OrderByDescending(property).ToList();
		}
		sortOrder = !sortOrder;
	}
}
usage
c#
SortCol(q => q.Name);
<hr/>
now you can create the expression using dynamic property name:
c#
public Expression<Func<RemoteComputer,T>> CreateExpressionByName<T>(string propertyName)
{	
	ParameterExpression param = Expression.Parameter(typeof(RemoteComputer) , "q");
	MemberExpression x = Expression.PropertyOrField(param, propertyName);
	var lambda = Expression.Lambda<Func<RemoteComputer, T>>(x, param);
	return lambda;
}
usage
c#
SortCol(CreateExpressionByName<string>("Name"));
