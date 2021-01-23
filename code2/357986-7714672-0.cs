    class CombineDynamic : DynamicObject
    {
        private readonly object[] m_objects;
        public CombineDynamic(params object[] objects)
        {
            m_objects = objects;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var callSite = CallSite<Func<CallSite, object, object>>.Create(binder);
            foreach (var o in m_objects)
            {
                try
                {
                    result = callSite.Target(callSite, o);
                    return true;
                }
                catch (RuntimeBinderException)
                {}
            }
            return base.TryGetMember(binder, out result);
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            // the binder from argument uses compile time type from call site,
            // which is object here; because of that, setting of properties that 
            // aren't of type object wouldn't work if we used that binder directly
            var fixedBinder = Binder.SetMember(
                CSharpBinderFlags.None, binder.Name, typeof(CombineDynamic),
                new[]
                {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
                });
            var callSite =
                CallSite<Action<CallSite, object, object>>.Create(fixedBinder);
            foreach (var o in m_objects)
            {
                try
                {
                    callSite.Target(callSite, o, value);
                    return true;
                }
                catch (RuntimeBinderException)
                {}
            }
            return base.TrySetMember(binder, value);
        }
    }
