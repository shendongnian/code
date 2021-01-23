    internal class MyProxy : RealProxy
    {
       public static IMySpecial Marshal( object instance )
       {
          MyProxy myProxy = new MyProxy( instance );
          return myProxy.GetTransparentProxy();
       }
       private object m_instance;    
       private MyProxy( object instance ) : base( typeof( IMySpecial ) )
       {
          m_instance = instance;
       }
    
      public override ObjRef CreateObjRef( Type requestedType )
      {
         throw new NotSupportedException();
      }
    
      public override IMessage Invoke( IMessage message )
      {
         IMethodCallMessage methodMessage =
            new MethodCallMessageWrapper( (IMethodCallMessage) message );
         // Obtain the actual method definition that is being called.
         MethodBase method = methodMessage.MethodBase;
         Type[] genericArgs = method.GetGenericArguments();//This is what you want
         return new ReturnMessage(...);
      }
    }
