    public enum EventHandlerTypes
    {
        SetInitialData // you can add additional shared handlers here and Factory<C>.Call - it.
    }
    public class SharedEventArgs : EventArgs
    {
        private object data;
        public SharedEventArgs(object data)
        {
            this.data = data;
        }
        public T GetData<T>()
        {
            return (T)data;
        }
    }
    public interface IBaseClass
    {
        void RegisterSharedHandlers(int? group, Action<IKey, int?, EventHandlerTypes, Action<object, SharedEventArgs>> regEvent);
        void RegisterSharedData(Action<IKey, object> regData);
    }
