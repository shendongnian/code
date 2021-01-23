    using System;
    using System.Reflection.Emit;
    public class MyClass1  {
        static void Main()
        {
            var foo = CreateMethod("Foo");
            string s = foo(123, 456);
            Console.WriteLine(s);
        }
        static Func<int,int,string> CreateMethod(string s)
        {
            var method = new DynamicMethod("DynamicallyDefonedMethod_" + s,
                typeof(string),
                new Type[] { typeof(int), typeof(int) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldstr, s);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.EmitCall(OpCodes.Call, typeof(MyClass1).GetMethod("StaticallyDefinedMethod"), null);
            il.Emit(OpCodes.Ret);
            return (Func<int,int,string>)method.CreateDelegate(typeof(Func<int, int, string>));
        }
        public static string StaticallyDefinedMethod(string s, int a, int b)
        {
            return s + "; " + a + "/" + b;
        }
    }
        
