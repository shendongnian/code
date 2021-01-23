    class SessionInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var method = invocation.Method;
            bool isGetter = method.IsSpecialName && method.Name.StartsWith("get_");
            bool isSetter = method.IsSpecialName && method.Name.StartsWith("set_");
            if (isGetter || isSetter)
            {
                string propertyName = method.Name.Substring(4);
                var property = invocation.TargetType.GetProperty(propertyName);
                bool hasSessionAttribute = property.GetCustomAttributes(typeof(SessionAttribute), false).Any();
                if (hasSessionAttribute)
                {
                    var session = ((IWithSession)invocation.InvocationTarget).Session;
                    if (isGetter)
                    {
                        invocation.ReturnValue = session[propertyName];
                        return;
                    }
                    else
                    {
                        session[propertyName] = invocation.Arguments[0];
                        return;
                    }
                }
            }
            invocation.Proceed();
        }
    }
