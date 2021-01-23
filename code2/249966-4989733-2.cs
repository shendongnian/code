    class SomeType { }
    delegate void SomeDelegateType(params object[] args);
    public class Program
    {
        public static void Main()
        {
            var dn = new DynamicMethod("foo", (Type)null, new[] {typeof(object[])});
            var il = dn.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldc_I4_0);
            il.Emit(OpCodes.Ldelem_Ref);
            il.EmitCall(OpCodes.Call, typeof(Program).GetMethod("Function"), null);
            il.Emit(OpCodes.Ret);
            var action = (SomeDelegateType)dn.CreateDelegate(typeof(SomeDelegateType));
            var obj = new SomeType();
            action(obj);
        }
        public static void Function(object obj)
        {
            Type type = obj.GetType();
            Console.WriteLine(type);
        }
    }
