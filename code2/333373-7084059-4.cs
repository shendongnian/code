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
            delegate void CachedMethodDelegate (object instance, object sender, EventArgs param);
            readonly static Dictionary<MethodInfo, CachedMethodDelegate> s_cachedMethods =
                new Dictionary<MethodInfo, CachedMethodDelegate> ();
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
                            && target is ISynchronizeInvoke
                            && ((ISynchronizeInvoke)target).InvokeRequired
                            )
                        {
                            ((ISynchronizeInvoke)target).Invoke (subDelegate, new[] { sender, param });
                        }
                        else
                        {
    #if USE_FAST_INVOKE
                            MethodInfo methodInfo = subDelegate.Method;
                            CachedMethodDelegate cachedMethodDelegate;
                            bool result;
                            lock (s_cachedMethods)
                            {
                                result = s_cachedMethods.TryGetValue (methodInfo, out cachedMethodDelegate);
                            }
                            if (!result)
                            {
                                cachedMethodDelegate = CreateDelegate (methodInfo);
                                lock (s_cachedMethods)
                                {
                                    s_cachedMethods[methodInfo] = cachedMethodDelegate;
                                }
                            }
                            cachedMethodDelegate (target, sender, param);
    #else
                            subDelegate.DynamicInvoke (sender, param);
    #endif
                        }
                    }
                }
            }
            static CachedMethodDelegate CreateDelegate (MethodInfo methodInfo)
            {
                if (!methodInfo.DeclaringType.IsClass)
                {
                    throw CreateArgumentExceptionForMethodInfo (
                        methodInfo, 
                        "Declaring type must be class for method: {0}.{1}"
                        );
                }
                if (methodInfo.ReturnType != typeof (void))
                {
                    throw CreateArgumentExceptionForMethodInfo (
                        methodInfo,
                        "Method must return void: {0}.{1}"
                        );
                }
                ParameterInfo[] parameters = methodInfo.GetParameters ();
                if (parameters.Length != 2)
                {
                    throw CreateArgumentExceptionForMethodInfo (
                        methodInfo,
                        "Method must have exactly two parameters: {0}.{1}"
                        );
                }
                if (parameters[0].ParameterType != typeof (object))
                {
                    throw CreateArgumentExceptionForMethodInfo (
                        methodInfo,
                        "Method first parameter must be of type object: {0}.{1}"
                        );
                }
                Type secondParameterType = parameters[1].ParameterType;
                if (!typeof (EventArgs).IsAssignableFrom (secondParameterType))
                {
                    throw CreateArgumentExceptionForMethodInfo (
                        methodInfo,
                        "Method second parameter must assignable to a variable of type EventArgs: {0}.{1}"
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
                // Below is equivalent to a method like this (if this was expressible in C#):
                //  void Invoke (object instance, object sender, EventArgs args)
                //  {
                //      ((<%=methodInfo.DeclaringType%>)instance).<%=methodInfo.Name%> (
                //          sender,
                //          (<%=secondParameterType%>)args
                //          );
                //  }
                ILGenerator ilGenerator = dynamicMethod.GetILGenerator ();
                ilGenerator.Emit (OpCodes.Ldarg_0);
                ilGenerator.Emit (OpCodes.Castclass, methodInfo.DeclaringType);
                ilGenerator.Emit (OpCodes.Ldarg_1);
                ilGenerator.Emit (OpCodes.Ldarg_2);
                ilGenerator.Emit (OpCodes.Castclass, secondParameterType);
                ilGenerator.EmitCall (OpCodes.Call, methodInfo, null);
                ilGenerator.Emit (OpCodes.Ret);
                return (CachedMethodDelegate)dynamicMethod.CreateDelegate (typeof (CachedMethodDelegate));
            }
            static Exception CreateArgumentExceptionForMethodInfo (
                MethodInfo methodInfo, 
                string message
                )
            {
                return new ArgumentException (
                    string.Format (
                        CultureInfo.InvariantCulture,
                        message,
                        methodInfo.DeclaringType.FullName,
                        methodInfo.Name
                        ),
                    "methodInfo"
                    );
            }
            class MyEventListener
            {
                public int Count;
                public void Receive (object sender, MyEventArgs param)
                {
                    ++Count;
                }
            }
            class MyEventArgs : EventArgs
            {
            
            }
            delegate void MyEventHandler (object sender, MyEventArgs args);
            class MyEventSource
            {
                public event MyEventHandler AnEvent;
                public void InvokeAnEvent (MyEventArgs arg2)
                {
                    InvokeExternal (AnEvent, this, arg2);
                }
            }
            static void Main (string[] args)
            {
                MyEventListener eventListener = new MyEventListener ();
                MyEventSource eventSource = new MyEventSource ();
                eventSource.AnEvent += eventListener.Receive;
                MyEventArgs eventArgs = new MyEventArgs ();
                eventSource.InvokeAnEvent (eventArgs);
                const int count = 3000000;
                DateTime then = DateTime.Now;
                for (int iter = 0; iter < count; ++iter)
                {
                    eventSource.InvokeAnEvent (eventArgs);
                }
                TimeSpan diff = DateTime.Now - then;
                Console.WriteLine (
                    "{0} calls took {1:0.00} seconds (listener received {2} calls)",
                    count,
                    diff.TotalSeconds,
                    eventListener.Count
                    );
                Console.ReadKey ();
            }
        }
    }
