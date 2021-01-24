    Type control = mainWindow.GetType();
    PropertyInfo l_propInfo = control.GetProperty("PropElementHighlighter", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
    var propertyValue = l_propInfo.GetValue(mainWindow);
    MethodInfo l_HighlightMethodInfo = l_propInfo.PropertyType.GetMethod("MyMethod");
    l_HighlightMethodInfo.Invoke(propertyValue, new object[] { "Parameter1" });
