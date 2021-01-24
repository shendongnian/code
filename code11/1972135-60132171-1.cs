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
