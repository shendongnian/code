    public interface IHandler
    {
        void ProcessMessage(dynamic message);
    }
    public class Handler<T> : IHandler
    {
        public void ProcessMessage(dynamic message)
        {
        }
    }
    public class A{} public class B{} public class C{} public class D{}
    public class HandlerA : IHandler{
        public void ProcessMessage(dynamic message){}
    }
    public class HandlerB  : IHandler{
        public void ProcessMessage(dynamic message) {}
    }
    public class HandlerC  : IHandler{
        public void ProcessMessage(dynamic message) {}
    }
    public class MsgProcessor
    {
        public Dictionary<Type, IHandler> handlers = new Dictionary<Type, IHandler>();
        public void AddHandler<T>(T o) where T: IHandler
        {
            handlers.Add(typeof(T),o);
        }
        public void ProcessMessage(dynamic message)
        {
            ProcessMessage(message);
        }
        public void ProcessMessage<T>(T message)
        {
            Handler<T> handler = (Handler<T>) handlers[typeof (T)];
            handler.ProcessMessage(message);
        }
    }
    public class Test
    {
        public void test()
        {
            var mp = new MsgProcessor();
            mp.AddHandler<HandlerA>(new HandlerA());
            mp.AddHandler<HandlerB>(new HandlerB());
            mp.AddHandler<HandlerC>(new HandlerC());
            mp.ProcessMessage(new A());
            mp.ProcessMessage(new B());
            mp.ProcessMessage(new C());
        }
    }
