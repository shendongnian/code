    using Castle.DynamicProxy;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Reflection;
    
    namespace LL.Utilities.Std.Json
    {
        public static class JObjectExtension
        {
            private static ProxyGenerator _generator = new ProxyGenerator();
    
            public static dynamic toProxy(this JObject targetObject, Type interfaceType) 
            {
                return _generator.CreateInterfaceProxyWithoutTarget(interfaceType, new JObjectInterceptor(targetObject));
            }
    
            public static InterfaceType toProxy<InterfaceType>(this JObject targetObject)
            {
                
                return toProxy(targetObject, typeof(InterfaceType));
            }
        }
    
        [Serializable]
        public class JObjectInterceptor : IInterceptor
        {
            private JObject _target;
    
            public JObjectInterceptor(JObject target)
            {
                _target = target;
            }
            public void Intercept(IInvocation invocation)
            {
                
                var methodName = invocation.Method.Name;
                if(invocation.Method.IsSpecialName && methodName.StartsWith("get_"))
                {
                    var returnType = invocation.Method.ReturnType;
                    methodName = methodName.Substring(4);
    
                    if (_target == null || _target[methodName] == null)
                    {
                        if (returnType.GetTypeInfo().IsPrimitive || returnType.Equals(typeof(string)))
                        {
                            
                            invocation.ReturnValue = null;
                            return;
                        }
                        
                    }
                    
                    if (returnType.GetTypeInfo().IsPrimitive || returnType.Equals(typeof(string)))
                    {
                        invocation.ReturnValue = _target[methodName].ToObject(returnType);
                    }
                    else
                    {
                        invocation.ReturnValue = ((JObject)_target[methodName]).toProxy(returnType);
                    }
                }
                else
                {
                    throw new NotImplementedException("Only get accessors are implemented in proxy");
                }
    
            }
        }
    
       
    
    }
