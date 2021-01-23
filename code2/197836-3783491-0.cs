    public class MyClass
    {
        public event EventHandler MyEvent;
        public IEnumerable<MethodInfo> GetSubscribedMethods()
        {
            Func<EventInfo, FieldInfo> ei2fi =
                ei => this.GetType().GetField(ei.Name,
                    BindingFlags.NonPublic |
                    BindingFlags.Instance |
                    BindingFlags.GetField);
            return from eventInfo in this.GetType().GetEvents()
                   let eventFieldInfo = ei2fi(eventInfo)
                   let eventFieldValue =
                       (System.Delegate)eventFieldInfo.GetValue(this)
                   from subscribedDelegate in eventFieldValue.GetInvocationList()
                   select subscribedDelegate.Method;
        }
    }
