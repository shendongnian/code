    using System;
    using System.Reflection;
    using System.Reflection.Emit;
    
    namespace AssemblyGenerator
    {
    	partial class AssemblyGenerator
    	{
    		static void Main(string[] args)
    		{
    			string assemblyName = "Sample";
    			string exeName = "Sample.exe";
    
    			AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName(assemblyName), AssemblyBuilderAccess.Save);
    			ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(exeName);
    			TypeBuilder typeBuilder = moduleBuilder.DefineType(assemblyName, TypeAttributes.Public | TypeAttributes.Class);
    			MethodBuilder methodBuilder = typeBuilder.DefineMethod("Main", MethodAttributes.Static | MethodAttributes.Public, typeof(void), null);
    
    			assemblyBuilder.SetEntryPoint(methodBuilder, PEFileKinds.ConsoleApplication);
    
    			ILGenerator ilGenerator = methodBuilder.GetILGenerator();
    			// BEGIN method IL.
    			ilGenerator.EmitWriteLine("This shows on console output.");
    			ilGenerator.Emit(OpCodes.Ret);
    			// END method IL.
    
    			typeBuilder.CreateType();
    			assemblyBuilder.Save(exeName);
    		}
    	}
    }
