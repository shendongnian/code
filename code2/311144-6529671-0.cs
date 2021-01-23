    using System;
    using Quartz;
    using System.Reflection;
    using System.Reflection.Emit;
    
    namespace TestQuartzTaskCreator {
        public class FakeJob {
            public static Type Create(string assemblyName, string typeName){
                AssemblyName aName = new AssemblyName(assemblyName);
                AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly(
                        aName,
                        AssemblyBuilderAccess.RunAndSave);
    
                ModuleBuilder mb = ab.DefineDynamicModule(aName.Name, aName.Name + ".dll");
    
                TypeBuilder tb = mb.DefineType(typeName, TypeAttributes.Public);
    
                tb.AddInterfaceImplementation(typeof(IJob));
    
                MethodBuilder meth = tb.DefineMethod(
                    "Execute",
                    MethodAttributes.Public | MethodAttributes.Virtual,
                    typeof(void),
                    new Type[] { typeof(JobExecutionContext) });
    
                meth.DefineParameter(1,
                    ParameterAttributes.In,
                    "context");
    
                ILGenerator methIL = meth.GetILGenerator();
                methIL.Emit(OpCodes.Ldarg_0);
    
                Type t = null;
                try {
                    // Finish the type.
                    t = tb.CreateType();
                }
                catch (Exception ex) {
                    System.Console.WriteLine(ex.ToString());
                }
    
    //            ab.Save(aName.Name + ".dll");
    
                return t;
            }
        }
    }
