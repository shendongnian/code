csharp
IQueryable<SalesOrder> ordersQuery = this.DbContext.SalesOrders
	.Include(so => so.Store)
		.ThenInclude(s => s.District)
	.Include(so => so.OrderingPlatform)
	.Include(so => so.Items)
		.ThenInclude(soi => soi.Items);
switch (scopeType)
{
	case ScopeType.Region:
		Region region = await this.DbContext.Regions
			.FirstOrDefaultAsync(r => r.Id == scopeId);
		if (region == null)
		{
			this.ModelState.AddModelError(nameof(scopeId), $"Failed to find a region with the specified id '{scopeId}'");
			return this.BadRequest(this.ModelState);
		}
		ordersQuery = ordersQuery.Where(so => so.Store.District.RegionId == region.Id);
		break;
	default:
		this.ModelState.AddModelError(nameof(scopeType), $"The specified scope type '{scopeType}' is not supported");
		return this.BadRequest(this.ModelState);
}
ordersQuery = ordersQuery
	.Where(so =>
		so.State == SalesOrderState.Prepared || so.State == SalesOrderState.Completed
		&& so.Destination == SalesOrderDestination.Customer
		&& so.DueDate.Date == DateTime.UtcNow.Date
	);
List<SalesOrder> orders = await ordersQuery.ToListAsync();
For the same use-case, the action takes few milliseconds instead of the 30/40seconds:
Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker:Information: Executed action Foo.Bar.Controllers.DashboardController.MySlowAction (Foo.Bar) in 269.9177ms
