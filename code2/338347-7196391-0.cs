    foreach (var type in System.Reflection.Assembly.GetExecutingAssembly().GetTypes())
    {
          if (type.Name.Equals("MyClass"))
          {
              MethodInfo mi = type.GetMethod("GetInstance", BindingFlags.Static);
              object o = mi.Invoke(t, null);
              break;
          }
    }
   
