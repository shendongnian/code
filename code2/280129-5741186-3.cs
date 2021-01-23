    class GenericActivator
    {
         private Dictionary<Type, List<Action<object>> _TypeListeners;
         public void Register<T>(Action<object> objectReceived)
         {
             List<Action<object>> listeners;
             if (!_TypeListeners.TryGet(typeof(T), out listeners)
             {
                 listeners = new List<Action<object>>();
             }
             listeners.Add(objectReceived);
         }
    }
