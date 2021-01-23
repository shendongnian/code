        public class Receiver
        {
            Dictionary<Type, MethodMapping> _handlers = new Dictionary<Type, MethodMapping>();
            Dictionary<string, Func<PduBase>> _factories = new Dictionary<string, Func<PduBase>>();
            // Small container making it easier to invoke each handler
            // also needed since different generic types cannot be stored in the same 
            // dictionary
            private class MethodMapping
            {
                public object Instance { get; set; }
                public MethodInfo Method { get; set; }
                public void Invoke(PduBase pdu)
                {
                    Method.Invoke(Instance, new[] {pdu});
                }
            }
            // add a method used to create a certain PDU type
            public void AddFactory(string name, Func<PduBase> factoryMethod)
            {
                _factories.Add(name, factoryMethod);
            }
            // register a class that handles a specific PDU type
            // we need to juggle a bit with reflection to be able to invoke it
            // hence everything is type safe outside this class, but not internally.
            // but that should be a sacrifice we can live with.
            public void Register<T>(IPduHandler<T> handler) where T : PduBase
            {
                var method = handler.GetType().GetMethod("Handle", new Type[] { typeof(T) });
                _handlers.Add(typeof(T), new MethodMapping{Instance = handler, Method = method});
            }
            // fake that we've received a new PDU
            public void FakeReceive(string pduName)
            {
               // create the PDU using the factory method
                var pdu = _factories[pduName]();
                // and invoke the handler.
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
            // we've recieved a PDU called "temp". 
            r.FakeReceive("temp");
        }
