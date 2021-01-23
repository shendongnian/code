    var importAssembly = System.Reflection.Assembly.LoadFile("test.dll");     
    Type[] types = importAssembly.GetTypes();
         foreach (Type type in types)
            {
            if (type.IsEnum)
            {
                   var enumName=type.Name;
                   foreach (var fieldInfo in type.GetFields())
                   {
                      if (fieldInfo.FieldType.IsEnum)
                      {
                          var fName=fieldInfo.Name;
                          var fValue=fieldInfo.GetRawConstantValue()
                      }
                  }
             }
        }
