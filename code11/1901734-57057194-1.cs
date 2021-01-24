    foreach (string monitorName in monitorsList)
    {
      Type monitorType = GetType().Assembly.GetType(monitorName);
      MethodInfo singleMonitorMethod = monitorType.GetMethod("SingleCheck");
      bool methodResult = (bool)singleMonitorMethod.Invoke(null, Array.Empty<object>());
    }
