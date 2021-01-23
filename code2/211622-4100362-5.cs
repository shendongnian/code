    public class EndpointConfig : IConfigureThisEndpoint, ISpecifyMessageHandlerOrdering
    {
         public void SpecifyOrder(Order order)
         {
              order.Specify(First<H1>.Then<H2>().AndThen<H3>().AndThen<H4>() //etc);
         }
    }
