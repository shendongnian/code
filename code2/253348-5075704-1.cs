            Dictionary<int, MethodInfo> dynamicActions = new Dictionary<int, MethodInfo>();
            
            dynamicActions[7] = Assembly.GetExecutingAssembly().GetType("ConsoleApplicationTest.Program").GetMethod("MyMethod", BindingFlags.Public | BindingFlags.Static);
            MethodInfo method;
            if (dynamicActions.TryGetValue(7, out method))
                method.Invoke(null, new object[0]);
