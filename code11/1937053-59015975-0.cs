c#
input.OrderItems.ForEach(async o =>
{
    if (!(await _salesItemManager.ReserveStock(o.SalesItemId, o.Quantity)).IsSuccess)
    {
        throw CodeException.ToAbpValidationException("OrderItem", "OrderItemCreate");
    }
});
Assign your async `ReserveStock` checks to an array of tasks that is awaited by the caller:
c#
var reserveStockChecks = input.OrderItems.Select(async o =>
{
    if (!(await _salesItemManager.ReserveStock(o.SalesItemId, o.Quantity)).IsSuccess)
    {
        throw CodeException.ToAbpValidationException("OrderItem", "OrderItemCreate");
    }
}).ToArray();
await Task.WhenAll(reserveStockChecks);
