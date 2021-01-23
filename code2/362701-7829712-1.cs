      MethodInfo mi = typeof(Foo).GetMethod("Bar", BindingFlags.NonPublic | BindingFlags.Static);
      ParameterInfo[] pis = mi.GetParameters();
      object[] parameters = new object[pis.Length];
      for (int i = 0; i < pis.Length; i++)
      {
        if (pis[i].IsOptional)
        {
          parameters[i] = pis[i].DefaultValue;
        }
      }
      mi.Invoke(null, parameters);
