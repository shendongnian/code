        /// <summary>
        /// Gets the EventHandler delegate attached to the specified event and object
        /// </summary>
        /// <param name="obj">object that contains the event</param>
        /// <param name="eventName">name of the event, e.g. "Click"</param>
        public static Delegate GetEventHandler(object obj, string eventName)
        {
            Delegate retDelegate = null;
            FieldInfo fi = obj.GetType().GetField("Event" + eventName, 
                                                   BindingFlags.NonPublic | 
                                                   BindingFlags.Static |
                                                   BindingFlags.Instance | 
                                                   BindingFlags.FlattenHierarchy |
                                                   BindingFlags.IgnoreCase);
            if (fi != null)
            {
                object value = fi.GetValue(obj);
                if (value is Delegate)
                    retDelegate = (Delegate)value;
                else if (value != null) // value may be just object
                {
                    PropertyInfo pi = obj.GetType().GetProperty("Events",
                                                   BindingFlags.NonPublic |
                                                   BindingFlags.Instance);
                    if (pi != null)
                    {
                        EventHandlerList eventHandlers = pi.GetValue(obj) as EventHandlerList;
                        if (eventHandlers != null)
                        {
                            retDelegate = eventHandlers[value];
                        }
                    }
                }
            }
            return retDelegate;
        }
