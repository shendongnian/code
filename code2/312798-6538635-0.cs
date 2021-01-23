    interface IMsg {}
    struct SMsg : IMsg { public int a, b, c, x, y, z; }
    class CMsg : IMsg { }
    interface IBar<T> where T : IMsg
    {
        public void M(T t);
    }
    class Pub<T> where T : IMsg
    {
        public static Action<T> DoIt(IBar<IMsg> bar)
        {
            return bar.M; // Why is this illegal?
        }
    }
