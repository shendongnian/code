    [Serializable]
    public class LoggerAttribute : OnExceptionAspect
    {
      public override void OnException(MethodExecutionEventArgs eventArgs)
      {
        Console.WriteLine(eventArgs.Method.DeclaringType.Name);
        Console.WriteLine(eventArgs.Method.Name);
        Console.WriteLine(eventArgs.Exception.StackTrace);
    
        ParameterInfo[] parameterInfos = eventArgs.Method.GetParameters();
        object[] paramValues = eventArgs.GetReadOnlyArgumentArray();
    
        for (int i = 0; i < parameterInfos.Length; i++)
        {
          Console.WriteLine(parameterInfos[i].Name + "=" + paramValues[i]);
        }
    
        eventArgs.FlowBehavior = FlowBehavior.Default;
      }
    }
