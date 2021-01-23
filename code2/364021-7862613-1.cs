    public interface IPacket
	{
		
	}
	public class FooPacket: IPacket {}
	public class PacketService
	{
		private static readonly ConcurrentDictionary<Type, Action<IPacket>> _Handlers = new ConcurrentDictionary<Type, Action<IPacket>>(new Dictionary<Type, Action<IPacket>>());
		public static void RegisterPacket<T>(Action<T> handler)
			where T: IPacket
		{
			_Handlers[typeof (T)] = packet => handler((T) packet);
		}
		private void ProcessReceivedPacket(IPacket packet)
		{
			Action<IPacket> handler;
			if (!_Handlers.TryGetValue(packet.GetType(), out handler))
			{
				// Error handling here. No packet handler exists for this type of packet.
				return;
			}
			handler(packet);
		}
	}
	class Program
	{
		private static PacketService _PacketService = new PacketService();
		static void Main(string[] args)
		{
			PacketService.RegisterPacket<FooPacket>(HandleFooPacket);
		}
		public static void HandleFooPacket(FooPacket packet)
		{
			// Do something with the packet
		}
	}
