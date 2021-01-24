///  Add "GetTypeServices(services)" to ConfigureServices in Startup.cs;
        public void GetTypeServices(IServiceCollection services)
        {
            var results = Assembly.GetExecutingAssembly().GetTypes()
                    .Where(x => typeof(ICustBillTypeService).IsAssignableFrom(x) 
                        && !x.IsInterface 
                        && !x.IsAbstract)
                    .Select(x => x.FullName).ToList();
            foreach(var result in results)
            {
                Type resultType = Type.GetType(result);
                MethodInfo typeMethod = resultType.GetMethod("RegisterTypeServices");                
                var t = Activator.CreateInstance(resultType);
                dynamic methodResult = typeMethod.Invoke(t, new object[] { services });                
            }
        }
Now Startup.cs does not have to be modified when we need to add a new service.  As long as the developer creates a new class inheriting the interface, it will be discovered automatically.
