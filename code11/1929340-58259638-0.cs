    public static class GameEventManager
    {
        private static Dictionary<Type, UnityEventBase> events = new Dictionary<Type, UnityEventBase>()
        {
            {
                typeof(LevelSceneLoadedGameEvent),
                new LevelSceneLoadedGameEvent()
            }
        };
    
        private static EventType GetEvent<EventType>() where EventType : UnityEventBase
        {
            UnityEventBase unityEvent = events[typeof(EventType)];
            return (EventType)unityEvent;
        }
    
        public static void SubscribeTo<EventType>(UnityAction listener) where EventType : UnityEvent
        {
            GetEvent<EventType>().AddListener(listener);
        }
    
        public static void UnsubscribeFrom<EventType>(UnityAction listener) where EventType : UnityEvent
        {
            GetEvent<EventType>().RemoveListener(listener);
        }
    
        public static void SubscribeTo<EventType, FirstParam>(UnityAction<FirstParam> listener) where EventType : UnityEvent<FirstParam>
        {
            GetEvent<EventType>().AddListener(listener);
        }
    
        public static void UnsubscribeFrom<EventType, FirstParam>(UnityAction<FirstParam> listener) where EventType : UnityEvent<FirstParam>
        {
            GetEvent<EventType>().RemoveListener(listener);
        }
    
        public static void Trigger<EventType>() where EventType : UnityEvent
        {
            GetEvent<EventType>().Invoke();
        }
    
        public static void Trigger<EventType, FirstParam>(FirstParam firstParam) where EventType : UnityEvent<FirstParam>
        {
            GetEvent<EventType>().Invoke(firstParam);
        }
    }
