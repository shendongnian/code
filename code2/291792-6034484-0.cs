    Dictionary<int,String> EDSDKErrorCodes = new Dictionary<int,String>;
    System.Reflection.FieldInfo[] fields = typeof(EDSDK).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
    foreach (System.Reflection.FieldInfo field in fields) {
      EDSDKErrorCodes[(uint)field.GetValue(null)] = field.Name;
    }
