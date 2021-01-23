    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.Remoting.Messaging;
    using System.Runtime.Remoting.Proxies;
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> listProxy = MyProxyGenerator.Create<IList<string>>(new ListProxy<string>(new List<string>() { "aa","bb" }));
            bool b1 = listProxy.Contains("aa");
            bool b2 = listProxy.Contains("cc");
            int count = listProxy.Count;
            string s = listProxy[1];
        }
        public class ListProxy<T>
        {
            private IList<T> _adaptee;
            //Only method needed by proxy generator
            object Adaptee
            {
                get { return _adaptee; }
            }
            public ListProxy(IList<T> adaptee)
            {
                _adaptee = adaptee;
            }
        }
        class MyProxyGenerator : RealProxy
        {
            Type _Type;
            object _Instance;
            public static T Create<T>(object instance)
            {
                return (T)new MyProxyGenerator(typeof(T),instance).GetTransparentProxy();
            }
        
            MyProxyGenerator(Type type,object instance) : base(type)
            {
                _Type = type;
                _Instance = instance.GetType().InvokeMember("get_Adaptee", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod, null, instance, null);
            }
            public override IMessage Invoke(IMessage msg)
            {
                IMethodCallMessage methodMessage = new MethodCallMessageWrapper((IMethodCallMessage)msg);
                string method = (string)msg.Properties["__MethodName"];
                object[] args = (object[])msg.Properties["__Args"];
                object retObj = _Instance.GetType().InvokeMember(method, BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod,null,_Instance,args);
                return new ReturnMessage(retObj,methodMessage.Args,methodMessage.ArgCount,methodMessage.LogicalCallContext,methodMessage);
            }
        }
    
    }
