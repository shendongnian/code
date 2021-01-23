    class MyFunnyProxyAttribute : System.Runtime.Remoting.Proxies.ProxyAttribute {
       public override MarshalByRefObject CreateInstance(Type serverType) {
          return null;
       }
    }
    [MyFunnyProxy]
    class MyFunnyType : ContextBoundObject { }
