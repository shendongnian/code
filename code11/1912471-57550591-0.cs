public class Order
{
	public Guid Id { get; }
	public Guid CustomerId { get; }
	public DateTime DateRegistered { get; }
	private readonly List<Item> _items = new List<Item>();
	public Order(Guid id, Guid customerId, DateTime dateRegistered)
	{
		Id = id;
		CustomerId = customerId;
		DateRegistered = dateRegistered;
	}
	public IEnumerable<Item> GetItems() => _items.AsReadOnly();
	public void AddItem(Guid productId, string description, decimal count, decimal unitPrice)
	{
		_items.Add(new Item(productId, description, count, unitPrice));
	}
	public class Item
	{
		// get-only properties
		internal Item(Guid productId, string description, decimal count, decimal unitPrice)
		{
		}
	}
}
There are variations but you should implement it in a way that you are comfortable with.  I prefer not to use aggregate instances when adding related objects such as the `Product` since that would mean my repository would need to somehow get to a `Product` when hydrating the `Order` instance.  One *could* have overloaded methods for `AddItem` where one takes the `productId` and the other a `Product` where the `product.Id` is used but I see little value in that.
The interesting thing about the `Order`->`Item` scenario is that the `OrderItem` table, in an entity-relationship model sense, is an *associative entity* (or link-table) between `Order` and `Product`.  However, we are all quite comfortable when dealing with this relationship and "*know*" that the items are related *closer* to the order and we model it as such.  The reason I mention this is that one runs in many such scenarios where the *side* you need to pick to create a one-to-many relationship is not quite a evident.
