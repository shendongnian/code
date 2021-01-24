    Type GetType(string typeName) {
       foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies()) {
           foreach (Type type in assembly.GetTypes()) {
               if (type.LastPartOfTypeName() == typeName) {
                   return type;
               }
           }
       }
       return null;
    }
