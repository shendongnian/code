    foreach (string monitorName in monitorsList)
    {
      Type monitorType = GetType().Assembly.GetExportedTypes().Single(x => x.Name == monitorName);
      MethodInfo singleMonitorMethod = monitorType.GetMethod("SingleCheck");
      bool methodResult = (bool)singleMonitorMethod.Invoke(null, Array.Empty<object>());
    }
