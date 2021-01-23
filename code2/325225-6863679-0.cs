	/// <summary>
	/// Represents an order, order lines are not accessible by other classes
	/// </summary>
	public class Order
	{
		private readonly List<OrderLine> _orderLines = new List<OrderLine>();
		public void AddOrderLineFromProperties(OrderLineProperties properties)
		{
			_orderLines.Add(properties.CreateOrderLine());
		}
	}
	/// <summary>
	/// Class which contains orderline information, before it is 
	/// "turned into a real orderline"
	/// </summary>
	public class OrderLineProperties
	{
		public OrderLine CreateOrderLine()
		{
			return new OrderLine();
		}
	}
	/// <summary>
	/// the concrete order line
	/// </summary>
	public class OrderLine
	{
	}
