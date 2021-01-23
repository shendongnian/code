    interface IMsg {}
    struct SMsg : IMsg { public int a, b, c, x, y, z; }
    class CMsg : IMsg { }
    interface IHandler<T> where T : IMsg
    {
        public void Notify(T t);
    }
    class Pub<T> where T : IMsg
    {
        public static Action<T> DoIt(IHandler<IMsg> handler)
        {
            return handler.Notify; // Why is this illegal?
        }
    }
