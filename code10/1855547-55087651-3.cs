    public static class WeakEventManagerHelper
    {
      
      public static void AddEventHandler<T, U>(string eventName, T eventSource, EventHandler<U> handler) where U : EventArgs
      {
        ThrowOnNullArg(eventName, eventSource, handler);
    
        EventInfo eventInfo = GetEventInfo(eventName, eventSource);
        ThrowIfEventNotExists(eventInfo, eventName);
    
        if (!eventInfo.AddMethod.IsPublic)
        {
          ThrowIfEventMethodIsNotPublic("add");
        }
    
        ThrowIfHandlerIsNotProper(eventInfo, handler);
    
        if (handler.Method.IsStatic && !IsCollectibleAssembly(handler))
        {
          AddStaticEventHandler(eventInfo, eventSource, handler);
        }
        else
        {
          AddInstanceEventHandler(eventName, eventSource, handler);
        }
      }       
    
      public static void RemoveEventHandler<T, U>(string eventName, T eventSource, EventHandler<U> handler) where U : EventArgs
      {
        ThrowOnNullArg(eventName, eventSource, handler);
    
        EventInfo eventInfo = GetEventInfo(eventName, eventSource);
        ThrowIfEventNotExists(eventInfo, eventName);
    
        if (!eventInfo.RemoveMethod.IsPublic)
        {
          ThrowIfEventMethodIsNotPublic("remove");
        }
    
        ThrowIfHandlerIsNotProper(eventInfo, handler);
    
        if (handler.Method.IsStatic && !IsCollectibleAssembly(handler))
        {
          RemoveStaticEventHandler(eventInfo, eventSource, handler);
        }
        else
        {
          RemoveInstanceEventHandler(eventName, eventSource, handler);
        }
      }
    
      private static void AddStaticEventHandler(EventInfo eventInfo, object eventSource, Delegate handler)
      {
        try
        {
          eventInfo.AddEventHandler(eventSource, handler);
        }
        catch
        {
          // Handling …
          throw;
        }      
      }
      
      private static void RemoveStaticEventHandler(EventInfo eventInfo, object eventSource, Delegate handler)
      {
        try
        {
          eventInfo.RemoveEventHandler(eventSource, handler);
        }
        catch
        {
          // Handling …
          throw;
        }      
      }
    
      private static void AddInstanceEventHandler<T, U>(string eventName, T eventSource, EventHandler<U> handler) where U : EventArgs
      {
        WeakEventManager<T, U>.AddHandler(
          eventSource,
          eventName,
          handler);
      }
    
      private static void RemoveInstanceEventHandler<T, U>(string eventName, T eventSource, EventHandler<U> handler) where U : EventArgs
      {
        WeakEventManager<T, U>.RemoveHandler(
          eventSource,
          eventName,
          handler);
      }
    
      private static EventInfo GetEventInfo<T>(string eventName, T eventSource)
      {
        return eventSource.GetType().GetEvent(eventName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
      }
    
      private static void ThrowOnNullArg<T, U>(string eventName, T eventSource, EventHandler<U> handler) where U : EventArgs
      {
        if (eventName == null)
        {
          throw new ArgumentNullException(nameof(eventName));
        }
        else if (eventSource == null)
        {
          throw new ArgumentNullException(nameof(eventSource));
        }
        else if (handler == null)
        {
          throw new ArgumentNullException(nameof(handler));
        }
      }
    
      private static void ThrowIfEventNotExists(EventInfo eventInfo, string eventName)
      {
        if (eventInfo == null)
        {
          throw new ArgumentException($"Event source does not contain event named {eventName}!");
        }
      }
    
      private static void ThrowIfEventMethodIsNotPublic(string method)
      {
        throw new ArgumentException($"Event {method} method is not public!");
      }
    
      private static void ThrowIfHandlerIsNotProper(EventInfo eventInfo, Delegate handler)
      {
        if (eventInfo.EventHandlerType != handler.GetType())
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
