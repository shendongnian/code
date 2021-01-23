	using System;
	using System.Reflection;
	using System.Reflection.Emit;
	using System.Threading;
	namespace SO5841769
	{
		
		class TestAttribute : Attribute
		{
			public string TestProperty { get; set; }
		}
		
		class Program
		{
			static void Main(string[] args)
			{
				AppDomain myDomain = Thread.GetDomain();
				AssemblyName myAsmName = new AssemblyName();
				myAsmName.Name = "MyDynamicAssembly";
				AssemblyBuilder myAsmBuilder = myDomain.DefineDynamicAssembly(myAsmName, AssemblyBuilderAccess.RunAndSave);
				ModuleBuilder myModBuilder = myAsmBuilder.DefineDynamicModule(myAsmName.Name, myAsmName.Name + ".dll");
				TypeBuilder myTypeBuilder = myModBuilder.DefineType("Data", TypeAttributes.Public);
				FieldBuilder someFieldBuilder = myTypeBuilder.DefineField("someField", typeof(string), FieldAttributes.Private); 
				PropertyBuilder somePropertyBuilder = myTypeBuilder.DefineProperty("SomeProperty", PropertyAttributes.HasDefault, typeof(string), null);
				MethodAttributes getSetAttr = MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig;
				ConstructorInfo displayCtor = typeof(TestAttribute).GetConstructor(new Type[] { });
				PropertyInfo conProperty = typeof (TestAttribute).GetProperty("TestProperty");
				CustomAttributeBuilder displayAttrib = new CustomAttributeBuilder(displayCtor, new object[] {}, new[] {conProperty}, new object[] {"Hello"});
				somePropertyBuilder.SetCustomAttribute(displayAttrib);
				MethodBuilder somePropertyGetPropMthdBldr = myTypeBuilder.DefineMethod("get_SomeProperty", getSetAttr, typeof(string), Type.EmptyTypes);
				ILGenerator somePropertyGetIL = somePropertyGetPropMthdBldr.GetILGenerator();
				somePropertyGetIL.Emit(OpCodes.Ldarg_0);
				somePropertyGetIL.Emit(OpCodes.Ldfld, someFieldBuilder);
				somePropertyGetIL.Emit(OpCodes.Ret);
				somePropertyBuilder.SetGetMethod(somePropertyGetPropMthdBldr);
				myTypeBuilder.CreateType();
				myAsmBuilder.Save(myAsmName.Name + ".dll");
			}
		}
	}
