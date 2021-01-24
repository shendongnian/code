    public class CheckOrderStatusConsumer : 
        IConsumer<CheckOrderStatus>
    {
        public async Task Consume(ConsumeContext<CheckOrderStatus> context)
        {
            var order = await _orderRepository.Get(context.Message.OrderId);
            if (order == null)
                await context.RespondAsync<OrderNotFound>(context.Message);
            else        
                await context.RespondAsync<OrderStatusResult>(new 
                {
                    OrderId = order.Id,
                    order.Timestamp,
                    order.StatusCode,
                    order.StatusText
                });
        }
    }
