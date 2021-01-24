    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    namespace ConsoleApp1
    {
        public interface IPacket
        {
            int Size { get; }
        }
        public class FooPacket : IPacket
        {
            public int    Size        => 10;
            public string FooProperty { get; set; }
        }
        public class BarPacket : IPacket
        {
            public int    Size        => 20;
            public string BarProperty { get; set; }
        }
        public class BazPacket : IPacket
        {
            public int    Size        => 20;
            public string BazProperty { get; set; }
        }
        public interface IPacketHandlerTag // "Tag" interface.
        {
        }
        public interface IPacketHandler<in T> : IPacketHandlerTag where T : IPacket
        {
            void HandlePacket(T packet);
        }
        public class FooPacketHandler : IPacketHandler<FooPacket>
        {
            public void HandlePacket(FooPacket packet)
            {
                Console.WriteLine("Handling FooPacket");
            }
        }
        public class BarPacketHandler : IPacketHandler<BarPacket>
        {
            public void HandlePacket(BarPacket packet)
            {
                Console.WriteLine("Handling BarPacket");
            }
        }
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
        class Program
        {
            public static void Main()
            {
                var packetHandlers = new List<IPacketHandlerTag>
                {
                    new FooPacketHandler(),
                    new BarPacketHandler()
                };
                var manager = new PacketHandlerManager(packetHandlers);
                var foo = new FooPacket();
                var bar = new BarPacket();
                var baz = new BazPacket();
                manager.HandlePacket(foo);
                manager.HandlePacket(bar);
                manager.HandlePacket(baz);
            }
        }
    }
