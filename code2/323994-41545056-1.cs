    namespace ConsoleApplication7
    {
        static class TypeBuilderExtension
        {
            public static int GetConstructorCount(this TypeBuilder t)
            {
                FieldInfo constCountField = typeof(TypeBuilder).GetField("m_constructorCount", BindingFlags.NonPublic | BindingFlags.Instance);
                return (int) constCountField.GetValue(t);
            }
        }
    
        class Program
        {  
            static void Main(string[] args)
            {
                AppDomain ad = AppDomain.CurrentDomain;
                AssemblyBuilder ab = ad.DefineDynamicAssembly(new AssemblyName("toto.dll"), AssemblyBuilderAccess.RunAndSave);
                ModuleBuilder mb = ab.DefineDynamicModule("toto.dll");
                TypeBuilder tb = mb.DefineType("mytype");
                
                Console.WriteLine("before constructor creation : " + tb.GetConstructorCount());
    
                ConstructorBuilder cb = tb.DefineConstructor(MethodAttributes.Public, CallingConventions.HasThis, new Type[0]);
                ILGenerator ilgen = cb.GetILGenerator();
                ilgen.Emit(OpCodes.Ret);
                Console.WriteLine("after constructor creation : " + tb.GetConstructorCount());
    
                tb.CreateType();
                ab.Save("toto.dll");
            }
        }
    }
