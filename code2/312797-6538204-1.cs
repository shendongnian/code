    public interface IMsg { }        // Doesn't work
    public class Msg : IMsg { }
    public class Pub<T> where T : IMsg
    {
        public event Action<T> notify;
        public void Subscribe(object subscriber)
        {
            IHandler<T> implementer = subscriber as IHandler<T>; // here
            
            if (implementer != null)
            {
                this.notify += implementer.NotifyEventHandler;
            }
        }
    }
    public interface IHandler<T> where T : IMsg
    {
        void NotifyEventHandler(T data);
    }
