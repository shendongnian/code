         Assembly assembly = Assembly.GetExecutingAssembly();
         foreach (var type in assembly.GetTypes())
         {
            if (type.Namespace.StartsWith("MyProject") && type.Namespace.EndsWith("Attribute"))
            {
               Console.WriteLine(type.FullName);
            }
         }
