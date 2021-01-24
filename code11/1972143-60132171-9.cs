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
// this method creates an Expression<Func<RemoteComputer,object>>
// and returning its compiled() resutl. Func<RemoteComputer,object>
// so you can use this `Func` in your orderBy methods.
public Func<RemoteComputer, object> GetProperty(string propertyName)
{
// q =>
	ParameterExpression param = Expression.Parameter(typeof(RemoteComputer), "q");
// q.propertyName  
// for example : q.Name
	MemberExpression member = Expression.PropertyOrField(param, propertyName);
// change property type to object (because we want to use all posible types of our class peroperties or fields)
	var body = Expression.Convert(member, typeof(object));
// create Expression<Func<RemoteComputer,object>>
	var property = Expression.Lambda<Func<RemoteComputer, object>>(body, param);
// returns a Func<RemoteComputer,object>
	return property.Compile();
}
 
