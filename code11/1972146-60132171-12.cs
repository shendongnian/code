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
public Func<T, object> GetProperty<T>(string propertyName)
{
// q =>
	ParameterExpression param = Expression.Parameter(typeof(T), "q");
// q.propertyName  
// for example : q.Name
	MemberExpression member = Expression.PropertyOrField(param, propertyName);
// change property type to object (because we want to use all posible types of our class peroperties or fields)
	var body = Expression.Convert(member, typeof(object));
// create Expression<Func<RemoteComputer,object>>
	var property = Expression.Lambda<Func<T, object>>(body, param);
// returns a Func<T,object>
	return property.Compile();
}
<hr/>
***Update***
you can use this extension class also to add OrderBy string support to your lists in the entire application. this also works for IQueriable queries.
c#
public static class OrderByExtentions
{
	public static IOrderedEnumerable<T> OrderByDescending<T>(this IEnumerable<T> list, string propertyName )
	{
		return list.OrderByDescending(GetPropertyFunc<T>(propertyName));
	}
	public static IQueryable<T> OrderByDescending<T>(this IQueryable<T> list, string propertyName)
	{
		return list.OrderByDescending(GetPropertyExpression<T>(propertyName));
	}
	public static IOrderedEnumerable<T> OrderBy<T>(this IEnumerable<T> list, string propertyName)
	{
		return list.OrderBy(GetPropertyFunc<T>(propertyName));
	}
	public static IQueryable<T> OrderBy<T>(this IQueryable<T> list, string propertyName)
	{
		return list.OrderBy(GetPropertyExpression<T>(propertyName));
	}
	private static Expression<Func<T, object>> GetPropertyExpression<T>(string propertyName)
	{
		ParameterExpression param = Expression.Parameter(typeof(T), "q");
		MemberExpression member = Expression.PropertyOrField(param, propertyName);
		var body = Expression.Convert(member, typeof(object));
		return Expression.Lambda<Func<T, object>>(body, param);
	}
	private static Func<T, object> GetPropertyFunc<T>(string propertyName)
	{
		return GetPropertyExpression<T>(propertyName).Compile();
	}
}
usage:
// eg. propName = "Name";
ou.Computers = ou.Computers.OrderByDescending(propName).ToList();
// or
 
ou.Computers = ou.Computers.OrderBy(propName).ToList();
