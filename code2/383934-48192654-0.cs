     class DynamicProxy<T> : RealProxy
        {
            readonly T decorated;
           
            public DynamicProxy(T decorated) : base(typeof(T))
            {
                this.decorated = decorated;
            }
    
            public override IMessage Invoke(IMessage msg)
            {
                var methodCall = msg as IMethodCallMessage;
                var methodInfo = methodCall.MethodBase as MethodInfo;
                string fullMethodName = $"{methodInfo.DeclaringType.Name}.{methodCall.MethodName}";
               
                try
                {
                    var result = methodInfo.Invoke(decorated, methodCall.InArgs);
    
                    return new ReturnMessage(result, null, 0, methodCall.LogicalCallContext, methodCall);
                }
             
                catch (Exception e)
                {
                    return new ReturnMessage(e, methodCall);
                }
                finally
                {
                }
            }
        }
