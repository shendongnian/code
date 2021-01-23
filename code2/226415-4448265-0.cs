            // Get all loaded assemblies in current application domain
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            // Get type of int
            Type intType = assemblies.Select(a => a.GetType("System.Int32")).First();
            // Create object of int using its type
            Object intObj = Activator.CreateInstance(intType);
            // Call int.ToString() method which returns '0'
            String result = intObj.GetType().GetMethod("ToString", new Type[] { }).Invoke(intObj, null).ToString();
