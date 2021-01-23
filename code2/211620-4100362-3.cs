    public class EndpointConfig : IConfigureThisEndpoint, ISpecifyMessageHandlerOrdering
    {
         public void SpecifyOrder(Order order)
         {
              order.Specify<FIRST<YourHandler>>();
         }
    }
