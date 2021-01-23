    internal class MyProxy : RealProxy
    {
       private object m_instance;    
       private MyProxy( object instance ) : base( typeof( IFactory) )
       {
          m_instance = instance;
       }
    
      public override IMessage Invoke( IMessage message )
      {
         IMethodCallMessage methodMessage =
            new MethodCallMessageWrapper( (IMethodCallMessage) message );
         // Obtain the actual method definition that is being called.
         MethodBase method = methodMessage.MethodBase;
         Type[] genericArgs = method.GetGenericArguments(); //This is what you want
         return new ReturnMessage(...);
      }
      ...
    }
