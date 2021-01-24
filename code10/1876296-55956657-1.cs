public class OrdersController : ApiController
{
    [Route("customers/{customerId}/orders/{effectiveDate?}")]
    [HttpPost]
    public IEnumerable<Order> UpdateOrdersByCustomer(int customerId, DateTime? effectiveDate) { ... }
}
