    public class OrderService : IOrderService
    {
        [WebGet(UriTemplate = "{orderId}/products/{productId}")]
        public Product GetOrderProduct(int orderId, int productId)
        {
            ...
        }
    }
