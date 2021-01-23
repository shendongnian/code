	public interface IPacket
	{
		
	}
	public class PacketService
	{
		private static ConcurrentDictionary<Type, Action<IPacket>> _Handlers = new ConcurrentDictionary<Type, Action<IPacket>>(new Dictionary<Type, Action<IPacket>>());
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
				// Error handling here
				return;
			}
			handler(packet);
		}
	}
