	public partial class Customer
	{
		public int CalculatedTotalOrders
		{
			get { return this.Orders.Sum(o => o.Total); }
		}
	}
