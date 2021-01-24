    class Program
    {
        static void Main(string[] args)
        {
            // Init List of method that I want to create
            var methods = new List<Method>();
            methods.Add(new Method()
            {
                Name = "Add",
                Params = new List<MethodParam>()
                {
                    new MethodParam()
                    {
                        Name = "a",
                        Type = typeof(int)
                    },
                    new MethodParam()
                    {
                        Name = "b",
                        Type = typeof(int)
                    }
                },
                ReturnType = typeof(int)
            });
            // Compile my type
            var myType = MyTypeBuilder.CompileResultType(methods);
            // Create instance of my type
            var myObject = Activator.CreateInstance(myType) as IFooContract;
            // Call Function
            var result = myObject.Add(5, 2);
            // Log
            Console.WriteLine(result);
            Console.Read();
        }
    }
    // Used to store Method Infos
    public class Method
    {
        public string Name;
        public List<MethodParam> Params;
        public Type ReturnType;
    }
    // Used to store Method param's Infos
    public class MethodParam
    {
        public string Name;
        public Type Type;
    }
    // Builder for the Dynamic class
    public static class MyTypeBuilder
    {
        public static Type CompileResultType(List<Method> methodList)
        {
            TypeBuilder tb = GetTypeBuilder();
            ConstructorBuilder constructor = tb.DefineDefaultConstructor(MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
            if (methodList != null)
            {
                // Loop throught all method definition
                foreach (var method in methodList)
                {
                    // Generate new method on the dynamic class
                    CreateMethod(tb, method);
                }
            }
            // Create the Dynamic class
            Type objectType = tb.CreateType();
            return objectType;
        }
        private static TypeBuilder GetTypeBuilder()
        {
            var typeSignature = "MyDynamicType";
            var an = new AssemblyName(typeSignature);
            AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(an, AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
            TypeBuilder tb = moduleBuilder.DefineType(typeSignature,
                    TypeAttributes.Public |
                    TypeAttributes.Class |
                    TypeAttributes.AutoClass |
                    TypeAttributes.AnsiClass |
                    TypeAttributes.BeforeFieldInit |
                    TypeAttributes.AutoLayout,
                    null,
                    new Type[] { typeof(IFooContract) }); // <= Interface that the Dynamic class will implement (used for intellisens)
            tb.AddInterfaceImplementation(typeof(IFooContract)); // <= Specify that the class will implement that interface
            return tb;
        }
        private static void CreateMethod(TypeBuilder tb, Method method)
        {
            // Create Method builder
            MethodBuilder mb = tb.DefineMethod(method.Name, MethodAttributes.Public | MethodAttributes.Virtual, method.ReturnType, method.Params.Select(x => x.Type).ToArray());
            // Get the IL Generator
            ILGenerator il = mb.GetILGenerator();
            // Start Build Method Body :
            // Load first parameter on evaluation stack
            il.Emit(OpCodes.Ldarg_1);
            // Load Second parameter on evaluation stack
            il.Emit(OpCodes.Ldarg_2);
            // Use the two last element loaded as operand for "+" operation
            il.Emit(OpCodes.Add);
            // Push the last element on evaluation stack as return of the function
            il.Emit(OpCodes.Ret);
            // Stop Build Method Body
            // Explicitly set this new function as the implementation of the interface function
            MethodInfo interfaceMethod = typeof(IFooContract).GetMethod(method.name);
            tb.DefineMethodOverride(mb, interfaceMethod);
        }
    }
