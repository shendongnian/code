        delegate void EventListener(EventInfoBase eventInfo);
        private class EventWrapper
        {
            public EventListener Action { get; set; }
            public object Token { get; set; }
        }
        Dictionary<System.Type, List<EventWrapper>> eventListeners = new Dictionary<System.Type, List<EventWrapper>>();
        public void RegisterListener<T>(System.Action<T> listener) where T : EventInfoBase
        {
            System.Type eventType = typeof(T);
            if (!eventListeners.ContainsKey(eventType) || eventListeners[eventType] == null)
            {
                eventListeners[eventType] = new List<EventWrapper>();
            }
            EventListener action = (ei) => { listener((T)ei); };
            var wrapper = new EventWrapper() { Action = action, Token = listener };
            eventListeners[eventType].Add(wrapper);
        }
        public void UnregisterListener<T>(System.Action<T> listener) where T : EventInfoBase
        {
            System.Type eventType = typeof(T);
            if (!eventListeners.ContainsKey(eventType) || eventListeners[eventType] == null)
            {
                return;
            }
            var toRemove = eventListeners[eventType].FirstOrDefault(x => x.Token.Equals(listener));
            if (toRemove != null)
            {
                eventListeners[eventType].Remove(toRemove);
            }
        }
