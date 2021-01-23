    // Comment this line to use DynamicInvoke instead as a comparison
    
    #define USE_FAST_INVOKE
    
    namespace DynInvoke
    {
        using System;
        using System.Globalization;
        using System.Reflection.Emit;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Reflection;
    
        static class Program
        {
            delegate void Action<TInput0, TInput1> (TInput0 input, TInput1 input1);
            delegate TResult Func<TInput0, TResult> (TInput0 input);
            delegate void CachedMethodDelegate (object instance, object sender, EventArgs param);
    
            readonly static Dictionary<MethodInfo, CachedMethodDelegate> s_cachedMethods =
                new Dictionary<MethodInfo, CachedMethodDelegate> ();
            
            readonly static Func<MethodInfo, CachedMethodDelegate> s_createDelegate = CreateDelegate2;
    
            static TValue GetOrAdd<TKey, TValue> (
                Dictionary<TKey, TValue> dictionary,
                TKey key,
                Func<TKey, TValue> creator
                )
            {
                TValue value;
                bool result;
    
                lock (dictionary)
                {
                    result = dictionary.TryGetValue (key, out value);
                }
    
                if (!result)
                {
                    value = creator (key);
                    lock (dictionary)
                    {
                        dictionary[key] = value;
                    }
                }
    
                return value;
            }
    
            public static void InvokeExternal (Delegate d, object sender, EventArgs param)
            {
                if (d != null)
                {
                    Delegate[] invocationList = d.GetInvocationList ();
                    foreach (Delegate subDelegate in invocationList)
                    {
                        object target = subDelegate.Target;
                        if (
                                target != null
                            &&  target is ISynchronizeInvoke
                            &&  ((ISynchronizeInvoke)target).InvokeRequired
                            )
                        {
                            ((ISynchronizeInvoke)target).Invoke (subDelegate, new[] { sender, param });
                        }
                        else
                        {
    #if USE_FAST_INVOKE
                            MethodInfo methodInfo = subDelegate.Method;
    
                            CachedMethodDelegate del = GetOrAdd (s_cachedMethods, methodInfo, s_createDelegate);
    
                            del (target, sender, param);
    #else
                            dDelgate.DynamicInvoke (sender, param);
    #endif
                        }
                    }
                }
            }
    
            static CachedMethodDelegate CreateDelegate2(MethodInfo methodInfo)
            {
                if (!methodInfo.DeclaringType.IsClass)
                {
                    throw new ArgumentException (
                        string.Format (CultureInfo.InvariantCulture,
                        "Declaring type must be class for method: {0}.{1}", 
                        methodInfo.DeclaringType.FullName,
                        methodInfo.Name
                        ),
                        "methodInfo"
                        );
                }
    
                DynamicMethod dynamicMethod = new DynamicMethod (
                    string.Format (
                        CultureInfo.InvariantCulture,
                        "Run_{0}_{1}",
                        methodInfo.DeclaringType.Name,
                        methodInfo.Name
                        ),
                    null,
                    new[]
                        {
                            typeof (object),
                            typeof (object),
                            typeof (EventArgs)
                        },
                        true
                    );
    
                ILGenerator ilGenerator = dynamicMethod.GetILGenerator ();
                ilGenerator.Emit (OpCodes.Ldarg_0);
                ilGenerator.Emit (OpCodes.Castclass, methodInfo.DeclaringType);
                ilGenerator.Emit (OpCodes.Ldarg_1);
                ilGenerator.Emit (OpCodes.Ldarg_2);
                ilGenerator.EmitCall (OpCodes.Call, methodInfo, null);
                ilGenerator.Emit (OpCodes.Ret);
    
                return (CachedMethodDelegate) dynamicMethod.CreateDelegate (typeof (CachedMethodDelegate));
    
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
    
                public void InvokeAnEvent(EventArgs arg2)
                {
                    InvokeExternal(AnEvent, this, arg2);
                }
            }
    
            static void Main(string[] args)
            {
    
                MyEventListener eventListener = new MyEventListener ();
                MyEventSource eventSource = new MyEventSource ();
    
                eventSource.AnEvent += eventListener.Receive;
    
                EventArgs eventArgs = new EventArgs ();
                eventSource.InvokeAnEvent (eventArgs);
    
                const int Count = 3000000;
    
                DateTime then = DateTime.Now;
    
                for (int iter = 0; iter < Count; ++iter)
                {
                    eventSource.InvokeAnEvent (eventArgs);
                }
    
                TimeSpan diff = DateTime.Now - then;
    
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
