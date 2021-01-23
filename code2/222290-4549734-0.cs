    /// <summary>
    /// Invokes actions in alternate AppDomains
    /// </summary>
    public static class DomainInvoker
    {
        /// <summary>
        /// Invokes the supplied delegate in a new AppDomain and then unloads when it is complete
        /// </summary>
        public static T ExecuteInNewDomain<T>(Delegate delegateToInvoke, params object[] args)
        {
            AppDomain invocationDomain = AppDomain.CreateDomain("DomainInvoker_" + delegateToInvoke.GetHashCode());
    
            T returnValue = default(T);
            try
            {
                var context = new InvocationContext(delegateToInvoke, args);
                invocationDomain.DoCallBack(new CrossAppDomainDelegate(context.Invoke));
    
                returnValue = (T)invocationDomain.GetData("InvocationResult_" + invocationDomain.FriendlyName);
            }
            finally
            {
                AppDomain.Unload(invocationDomain);
            }
            return returnValue;
        }
    
        [Serializable]
        internal sealed class InvocationContext
        {
            private Delegate _delegateToInvoke;
            private object[] _arguments;
    
            public InvocationContext(Delegate delegateToInvoke, object[] args)
            {
                _delegateToInvoke = delegateToInvoke;
                _arguments = args;
            }
    
            public void Invoke()
            {
                if (_delegateToInvoke != null)
                    AppDomain.CurrentDomain.SetData("InvocationResult_" + AppDomain.CurrentDomain.FriendlyName,
                        _delegateToInvoke.DynamicInvoke(_arguments));
            }
        }
    }
