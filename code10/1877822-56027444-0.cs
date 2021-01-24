            // The assembly might not be there. Or we can't load it.
            Assembly assembly = Assembly.LoadFile(@"C:\Users\myUser\source\repos\TestMathHelper\TestMathHelper\bin\Debug\MathHelper.dll");  
          
            // The assembly doesn't have a type with that name.
            Type type = assembly.GetType("MathHelper.Helper");
            // The type doesn't have a constructor with no arguments.
            object instance = Activator.CreateInstance(type);
            // The type doesn't have a method called "add".
            MethodInfo method = type.GetMethod("add");
            // The "add" method doesn't take two ints as arguments or doesn't return an int.
            int result = (int)method.Invoke(instance, new object[] {4, 5});
