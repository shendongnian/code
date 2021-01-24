        Dictionary<System.Type, List<object>> eventListeners = new Dictionary<System.Type, List<object>>();
        public void RegisterListener<T>(System.Action<T> listener) where T : EventInfoBase
        {
            System.Type eventType = typeof(T);
            if (!eventListeners.ContainsKey(eventType) || eventListeners[eventType] == null)
            {
                eventListeners[eventType] = new List<object>();
            }
            eventListeners[eventType].Add(listener);
        }
        public void UnregisterListener<T>(System.Action<T> listener) where T : EventInfoBase
        {
            System.Type eventType = typeof(T);
            if (!eventListeners.ContainsKey(eventType) || eventListeners[eventType] == null)
            {
                return;
            }
            var toRemove = eventListeners[eventType].Find(x => x.Equals(listener));
            if (toRemove != null)
            {
                eventListeners[eventType].Remove(toRemove); 
            }
        }
