    public class QueryWindow
    {
        public void RegisterEvent(object targetObject, string eventName, string methodName)
        {
            var eventInfo = targetObject.GetType().GetEvent(eventName);
            var sender = Expression.Parameter(typeof (object), "sender");
            var e = Expression.Parameter(typeof (EventArgs), "e");
            var body = Expression.Call(Expression.Constant(this), methodName, null, e);
            var lambda = Expression.Lambda(eventInfo.EventHandlerType, body, sender, e);
            eventInfo.AddEventHandler(targetObject, lambda.Compile() );
        }
    
        public void OnEvent(object o)
        {
            Console.WriteLine(o);
        }
    }
