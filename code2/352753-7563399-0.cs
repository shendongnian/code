    Type[] types = typeof(Test).GetInterfaces();
     foreach (var m in types)
      {
        if (m.IsAssignableFrom(typeof(Test)))
         {
           //
         }
      }
