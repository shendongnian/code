    interface IMsg {}
    interface IHandler<T> where T : IMsg
    {
        public void Notify(T t);
    }
    class Pub<T> where T : IMsg
    {
        public static Action<T> MakeSomeAction(IHandler<IMsg> handler)
        {
            return handler.Notify; // Why is this illegal?
        }
    }
