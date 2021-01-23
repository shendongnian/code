	public class OrderProcessor : IOrderProcessor
	{
	    public void Process(Order order)
	    {
	        var validator = Locator.Resolve<IOrderValidator>();
	        if (validator.Validate(order))
	        {
	            var shipper = Locator.Resolve<IOrderShipper>();
	            shipper.Ship(order);
	        }
	    }
	}
