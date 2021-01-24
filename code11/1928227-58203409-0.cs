    public class PacketHandlerManager
    {
        public PacketHandlerManager(IEnumerable<IPacketHandlerTag> packetHandlers)
        {
            foreach (var packetHandler in packetHandlers)
            {
                bool appropriateMethodFound = false;
                var handlerType = packetHandler.GetType();
                var allMethods  = handlerType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
                foreach (var method in allMethods.Where(m => m.Name == "HandlePacket"))
                {
                    var args = method.GetParameters();
                    if (args.Length == 1 && typeof(IPacket).IsAssignableFrom(args[0].ParameterType))
                    {
                        _handlers.Add(args[0].ParameterType, item => method.Invoke(packetHandler, new object[]{item}));
                        appropriateMethodFound = true;
                    }
                }
                if (!appropriateMethodFound)
                    throw new InvalidOperationException("No appropriate HandlePacket() method found for type " + handlerType.FullName);
            }
        }
        public void HandlePacket(IPacket packet)
        {
            if (_handlers.TryGetValue(packet.GetType(), out var handler))
            {
                handler(packet);
            }
            else
            {
                Console.WriteLine("No handler found for packet type " + packet.GetType().FullName);
            }
        }
        readonly Dictionary<Type, Action<IPacket>> _handlers = new Dictionary<Type, Action<IPacket>>(); 
    }
