     protected void Application_Start()
        {           
            EntityFrameworkConfig.RegisterSettings();
        }
     public static class EntityFrameworkConfig
    {
        public static void RegisterSettings()
        {
            // Use the file name to load the assembly into the current
            // application domain.
            Assembly a = Assembly.Load("MyAssembly");
            // Get the type to use.
            Type myType = a.GetType("MyType");
            // Get the method to call.
            MethodInfo myMethod = myType.GetMethod("MySettingsMethod");
            // Create an instance.
            object obj = Activator.CreateInstance(MyType);
            // Execute the method.
            myMethod.Invoke(obj, null);
        }
    }
      public void Configurations()
        {
          //Other settings
            Database.SetInitializer<myDbContext>(null);
        }
