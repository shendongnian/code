     private ParentClass populateGenericParameter(ParentClass inputParameter, ExternalObject value) {
         const string methodToInvoke = "initializeParameter";
         ParentClass populatedParameter = null;
         try {
            MethodInfo method = typeof(this).GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            Type type = typeof(ChildClass<>).MakeGenericType(new Type[] {inputParameter.GetType()}).GetGenericArguments()[0].GetGenericArguments()[0];
            if(type != null) {
               MethodInfo genericMethod = method.MakeGenericMethod(type);
               object[] methodArguments = new object[] {inputParameter, value};
               populatedParameter = (ParentClass) genericMethod.Invoke(obj: this, parameters: methodArguments);
            }
         }
         catch(Exception e) {
            //logging here
         }
         return populatedParameter;
     }
