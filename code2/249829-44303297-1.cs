	public class OrderProcessor : IOrderProcessor
	{
		public OrderProcessor(IOrderValidator validator, IOrderShipper shipper)
		{
			this.validator = validator; 
			this.shipper = shipper;
		}
		public void Process(Order order)
		{
			if (this.validator.Validate(order))
			{
			    shipper.Ship(order);
			}
	    }
	}
	//Caller
	public static void main() //this can be a unit test code too.
	{
	var validator = Locator.Resolve<IOrderValidator>(); // similar to a IOC container 
	var shipper = Locator.Resolve<IOrderShipper>();
	var orderProcessor = new OrderProcessor(validator, shipper);
	orderProcessor.Process(order);
	}
