    // The Singleton.cs file.
    public abstract class Singleton<T> where T : ScriptEvent, new() //Type constraint
    {
        private static T _instance;
        public static T Instance => _instance ?? (_instance = new T());
    }
    // The ScriptEvent.cs file.
    public abstract class ScriptEvent  //No inheritance
    {
        public abstract void RaiseEvent(params object[] raiseParameters);
        public abstract void Subscribe(Delegate toSubscribe);
        public abstract void Unsubscribe(Delegate toUnsubscribe);
        public abstract Delegate[] GetSubscribers();
    }
