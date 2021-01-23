        public class Receiver
        {
            Dictionary<Type, MethodMapping> _handlers = new Dictionary<Type, MethodMapping>();
            Dictionary<string, Func<PduBase>> _factories = new Dictionary<string, Func<PduBase>>();
            private class MethodMapping
            {
                public object Instance { get; set; }
                public MethodInfo Method { get; set; }
                public void Invoke(PduBase pdu)
                {
                    Method.Invoke(Instance, new[] {pdu});
                }
            }
            public void AddFactory(string name, Func<PduBase> factoryMethod)
            {
                _factories.Add(name, factoryMethod);
            }
            public void Register<T>(IPduHandler<T> handler) where T : PduBase
            {
                var method = handler.GetType().GetMethod("Handle", new Type[] { typeof(T) });
                _handlers.Add(typeof(T), new MethodMapping{Instance = handler, Method = method});
            }
            public void FakeReceive(string pduName)
            {
                var pdu = _factories[pduName]();
                _handlers[pdu.GetType()].Invoke(pdu);
            }
        }
        public interface IPduHandler<in T> where T: PduBase
        {
            void Handle(T pdu);
        }
        public class TempPdu : PduBase
        {}
        public class TempPduHandler : IPduHandler<TempPdu>
        {
            public void Handle(TempPdu pdu)
            {
                Console.WriteLine("Handling pdu");
            }
        }
        public class PduBase
        { }
        private static void Main(string[] args)
        {
            Receiver r = new Receiver();
            r.AddFactory("temp", () => new TempPdu());
            r.Register(new TempPduHandler());
            // invoke
            r.FakeReceive("temp");
        }
