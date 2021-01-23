    // Comment this line to use DynamicInvoke instead as a comparison
    #define USE_FAST_INVOKE
    
    
    namespace DynInvoke
    {
        using System;
        using System.Collections.Concurrent;
        using System.Linq.Expressions;
        using System.Reflection;
    
        static class Program
        {
            delegate void CachedMethodDelegate (object instance, object sender, EventArgs param);
    
            readonly static ConcurrentDictionary<MethodInfo, CachedMethodDelegate> s_cachedMethods =
                new ConcurrentDictionary<MethodInfo, CachedMethodDelegate> ();
    
            public static void InvokeExternal(Delegate d, object sender, EventArgs param)
            {
                if (d != null)
                {
                    //Check each invocation target            
                    foreach (var dDelgate in d.GetInvocationList())
                    {
                        if (
                                dDelgate.Target != null
                            &&  dDelgate.Target is System.ComponentModel.ISynchronizeInvoke
                            &&  ((System.ComponentModel.ISynchronizeInvoke)(dDelgate.Target)).InvokeRequired
                            )
                        {
                            //If target is ISynchronizeInvoke and Invoke is required, invoke via ISynchronizeInvoke                    
                            ((System.ComponentModel.ISynchronizeInvoke)(dDelgate.Target)).Invoke(dDelgate, new object[] { sender, param });
                        }
                        else
                        {
    #if USE_FAST_INVOKE
                            var methodInfo = dDelgate.Method;
    
                            var del = s_cachedMethods.GetOrAdd (methodInfo, CreateDelegate);
    
                            del (dDelgate.Target, sender, param);
    #else
                            dDelgate.DynamicInvoke (sender, param);
    #endif
                        }
                    }
                }
            }
    
            static CachedMethodDelegate CreateDelegate (MethodInfo methodInfo)
            {
                var instance = Expression.Parameter (typeof (object), "instance");
                var sender = Expression.Parameter (typeof (object), "sender");
                var parameter = Expression.Parameter (typeof (EventArgs), "parameter");
    
                var lambda = Expression.Lambda<CachedMethodDelegate>(
                    Expression.Call (
                        Expression.Convert (instance, methodInfo.DeclaringType),
                        methodInfo,
                        sender,
                        parameter
                        ),
                    instance,
                    sender,
                    parameter
                    );
    
                return lambda.Compile ();
            }
    
            class MyEventListener
            {
                public int Count;
    
                public void Receive (object sender, EventArgs param)
                {
                    ++Count;
                }
            }
    
            class MyEventSource
            {
                public event Action<object, EventArgs> AnEvent;
    
                public void InvokeAnEvent (EventArgs arg2)
                {
                    InvokeExternal (AnEvent, this, arg2);
                }
            }
    
            static void Main(string[] args)
            {
    
                var eventListener = new MyEventListener ();
                var eventSource = new MyEventSource ();
    
                eventSource.AnEvent += eventListener.Receive;
    
                var eventArgs = new EventArgs ();
                eventSource.InvokeAnEvent (eventArgs);
    
                const int Count = 3000000;
    
                var then = DateTime.Now;
    
                for (var iter = 0; iter < Count; ++iter)
                {
                    eventSource.InvokeAnEvent (eventArgs);
                }
    
                var diff = DateTime.Now - then;
    
                Console.WriteLine (
                    "{0} calls took {1:0.00} seconds (listener received {2} calls)", 
                    Count, 
                    diff.TotalSeconds,
                    eventListener.Count
                    );
    
                Console.ReadKey ();
            }
        }
    }
