		public class SomeType
		{
			public virtual void DoNothing<T>()
			{
				Console.WriteLine(typeof(T));
			}
		}
		public abstract class MyAction
		{
			public abstract void Invoke(SomeType type);
		}
		public static void Main(string[] args)
		{
			TypeBuilder builder = AppDomain.CurrentDomain
				.DefineDynamicAssembly(new AssemblyName(MethodBase.GetCurrentMethod().DeclaringType.Name),
				                       AssemblyBuilderAccess.RunAndCollect)
				.DefineDynamicModule("Module").DefineType("MyType",
				                                          TypeAttributes.AnsiClass | TypeAttributes.AutoClass | TypeAttributes.Class |
				                                          TypeAttributes.Public | TypeAttributes.Sealed,
				                                          typeof (MyAction));
			var ilgen = builder.DefineMethod("Invoke",
			                                 MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.Final |
			                                 MethodAttributes.Virtual,
			                                 CallingConventions.HasThis,
			                                 typeof (void), new[] {typeof (SomeType)}).GetILGenerator();
			ilgen.Emit(OpCodes.Ldarg_1);
			ilgen.Emit(OpCodes.Dup);
			ilgen.Emit(OpCodes.Ldvirtftn, typeof (SomeType).GetMethod("DoNothing").MakeGenericMethod(typeof (int)));
			ilgen.Emit(OpCodes.Calli, SignatureHelper.GetMethodSigHelper(CallingConventions.HasThis, typeof (void)));
			ilgen.Emit(OpCodes.Ret);
			MyAction action = Activator.CreateInstance(builder.CreateType()) as MyAction;
			action.Invoke(new SomeType());
		}
