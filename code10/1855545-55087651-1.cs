    public static class WeakEventManagerHelper
    {
      /// <summary>
      /// Consumer access method for subscription.
      /// </summary>        
      public static void AddEventHandler<T, U>(string eventName, T eventSource, EventHandler<U> handler) where U : EventArgs
      {
    
        ThrowIfEventNotExists(eventName, eventSource);
        ThrowIfHandlerIsNotProper(eventName, eventSource, handler);
    
        if (handler.Method.IsStatic && !IsCollectibleAssembly(handler))
        {
          AddStaticEventHandler(eventName, eventSource, handler);
        }
        else
        {
          AddInstanceEventHandler(eventName, eventSource, handler);
        }
      }
    
      /// <summary>
      /// Consumer access method for unsubscription.
      /// </summary>        
      public static void RemoveEventHandler<T, U>(string eventName, T eventSource, EventHandler<U> handler) where U : EventArgs
      {
        
        ThrowIfEventNotExists(eventName, eventSource);
    
        if (handler.Method.IsStatic && !IsCollectibleAssembly(handler))
        {
          RemoveStaticEventHandler(eventName, eventSource, handler);
        }
        else
        {
          RemoveInstanceEventHandler(eventName, eventSource, handler);
        }
      }
    
      /// <summary>
      /// Static method handler addition.
      /// </summary>   
      private static void AddStaticEventHandler(string eventName, object eventSource, Delegate handler)
      { 
        eventSource
        .GetType()
        .GetEvent(eventName)
        .AddEventHandler(eventSource, handler);     
      }
    
      /// <summary>
      /// Static method handler removal.
      /// </summary>      
      private static void RemoveStaticEventHandler(string eventName, object eventSource, Delegate handler)
      {
        eventSource
        .GetType()
        .GetEvent(eventName)
        .RemoveEventHandler(eventSource, handler);
      }
    
      /// <summary>
      /// Instance method handler addition using WeakEventManager<TEventSource, TEventArgs>.
      /// </summary>  
      private static void AddInstanceEventHandler<T, U>(string eventName, T eventSource, EventHandler<U> handler) where U: EventArgs
      {
        WeakEventManager<T, U>.AddHandler(
          eventSource,
          eventName,
          handler);
      }
    
      /// <summary>
      /// Instance method handler removal using WeakEventManager<TEventSource, TEventArgs>.
      /// </summary>   
      private static void RemoveInstanceEventHandler<T, U>(string eventName, T eventSource, EventHandler<U> handler) where U : EventArgs
      {
        WeakEventManager<T, U>.RemoveHandler(
          eventSource,
          eventName,
          handler);
      }
    
    
      private static void ThrowIfEventNotExists(string eventName, object eventSource)
      {
        if (eventSource.GetType().GetEvent(eventName) == null)
        {
          throw new ArgumentException($"Event source does not contain event named {eventName}!");
        }
      }
    
      private static void ThrowIfHandlerIsNotProper(string eventName, object eventSource, Delegate handler)
      {
        if (eventSource.GetType().GetEvent(eventName).EventHandlerType != handler.GetType())
        {
          throw new ArgumentException($"Improper handler type {handler}!");
        }
      }
    
      private static bool IsCollectibleAssembly<U>(EventHandler<U> handler)
      {
        if (!handler.Method.DeclaringType.Assembly.IsDynamic)
        {
          return false;
        }
    
        try
        {
          Assembly handlerMethodAssembly = handler.Method.DeclaringType.Assembly;
    
          Type assemblyBuilderDataType = Assembly.GetAssembly(typeof(AssemblyBuilder))
              .GetType("System.Reflection.Emit.AssemblyBuilderData");
    
          object assemblyBuilderData = handlerMethodAssembly.GetType()
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .Single(fi => fi.FieldType == assemblyBuilderDataType)
            .GetValue(handlerMethodAssembly);
    
          object assemblyBuilderAccess = assemblyBuilderDataType
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .Single(fi => fi.FieldType == typeof(AssemblyBuilderAccess))
            .GetValue(assemblyBuilderData);
    
          return (AssemblyBuilderAccess)assemblyBuilderAccess == AssemblyBuilderAccess.RunAndCollect;
        }
        catch (Exception)
        {
          return false;
        }
      }
    }
