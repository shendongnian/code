public class OrdersController : ApiController
{
    [Route("customers/{customerId}/orders/{effectiveDate?}")]
    [HttpPatch]
    public IEnumerable<Order> UpdateOrdersByCustomer(int customerId, DateTime? effectiveDate) { ... }
}
