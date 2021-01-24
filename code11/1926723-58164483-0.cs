 c#
private IEventHandler<TEvent> GetHandler<TEvent>(Type type = null) where TEvent : IEvent
        {
            object handler;
            type = type ?? typeof(TEvent);
            if (_container.TryResolve(typeof(IEventHandler<>).MakeGenericType(type), out handler))
            {
                return (IEventHandler<TEvent>)handler;
            }
            else
            {
                foreach (var t in type.GetInterfaces())
                {
                    var h = GetHandler<TEvent>(t);
                    if (h != null)
                        return h;
                }
            }
            return null;
        }
