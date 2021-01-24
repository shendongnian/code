cs
public interface IOrderData
{
}
public class MoveOrderData : IOrderData
{
	public Vector3 Destination { get; private set; }
}
public class AttackOrderData : IOrderData
{
}
public abstract class OrderProcessor<T> where T : IOrderData
{
	protected T CurrentData { get; set; }
	public virtual void Start(T data)
	{
		CurrentData = data;
	}
}
public class MoveOrderProcessor : OrderProcessor<MoveOrderData>
{
}
public class AttackOrderProcessor : OrderProcessor<AttackOrderData>
{
}
public class OrderService
{
	private readonly Dictionary<Type, Action<object>> m_processors = new Dictionary<Type, Action<object>>();
	public OrderService()
	{
		AddProcessor(new MoveOrderProcessor());
		AddProcessor(new AttackOrderProcessor());
	}
	private void AddProcessor<T>(OrderProcessor<T> processor) where T : IOrderData
	{
		var action = (Action<T>)processor.Start;
		m_processors.Add(typeof(T), obj => action((T)obj));
	}
	public void GiveOrder(IOrderData data)
	{
		var action = m_processors[data.GetType()];
		action?.Invoke(data);
	}
}
It causes a downcasting `obj => action((T)obj)`, but it shouldn't be a problem, since your data is constrained to `IOrderData` interface. And the usage example
cs
var service = new OrderService();
service.GiveOrder(new MoveOrderData());
service.GiveOrder(new AttackOrderData());
