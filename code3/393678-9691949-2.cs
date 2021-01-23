    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Runtime.CompilerServices;
    
    namespace Test
    {
        public static class GCInterceptor
        {
            private static ConditionalWeakTable<object, CallbackRef> _table;
    
            static GCInterceptor()
            {
                _table = new ConditionalWeakTable<object, CallbackRef>();
            }
    
            public static void RegisterGCEvent(this object obj, Action<int> action)
            {
                CallbackRef callbackRef;
                bool found = _table.TryGetValue(obj, out callbackRef);
                if (found)
                {
                    callbackRef.Collected += action;
                    return;
                }
    
                int hashCode = RuntimeHelpers.GetHashCode(obj);
                callbackRef = new CallbackRef(hashCode);
                callbackRef.Collected += action;
                _table.Add(obj, callbackRef);
            }
    
            public static void DeregisterGCEvent(this object obj, Action<int> action)
            {
                CallbackRef callbackRef;
                bool found = _table.TryGetValue(obj, out callbackRef);
                if (!found)
                    throw new Exception("No events registered");
    
                callbackRef.Collected -= action;
            }
    
            private class CallbackRef
            {
                private int _hashCode;
                public event Action<int> Collected;
    
                public CallbackRef(int hashCode)
                {
                    _hashCode = hashCode;
                }
    
                ~CallbackRef()
                {
                    Action<int> handle = Collected;
                    if (handle != null)
                        handle(_hashCode);
                }
            }
        }
    }
