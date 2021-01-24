    using System;
    using System.Reflection.Emit;
    namespace ConsoleApp10
    {
        class Program
        {
            static Func<bool, int> BoolToInt;
            static Func<bool, byte> BoolToByte;
            static void Main(string[] args)
            {
                InitIL();
                Console.WriteLine(BoolToInt(true));
                Console.WriteLine(BoolToInt(false));
                Console.WriteLine(BoolToByte(true));
                Console.WriteLine(BoolToByte(false));
                Console.ReadLine();
            }
            static void InitIL()
            {
                var methodBoolToInt = new DynamicMethod("BoolToInt", typeof(int), new Type[] { typeof(bool) });
                var ilBoolToInt = methodBoolToInt.GetILGenerator();
                ilBoolToInt.Emit(OpCodes.Ldarg_0);
                ilBoolToInt.Emit(OpCodes.Ldc_I4_0);
                ilBoolToInt.Emit(OpCodes.Cgt_Un);
                ilBoolToInt.Emit(OpCodes.Ret);
                BoolToInt = (Func<bool, int>)methodBoolToInt.CreateDelegate(typeof(Func<bool, int>));
                var methodBoolToByte = new DynamicMethod("BoolToByte", typeof(byte), new Type[] { typeof(bool) });
                var ilBoolToByte = methodBoolToByte.GetILGenerator();
                ilBoolToByte.Emit(OpCodes.Ldarg_0);
                ilBoolToByte.Emit(OpCodes.Ldc_I4_0);
                ilBoolToByte.Emit(OpCodes.Cgt_Un);
                ilBoolToByte.Emit(OpCodes.Ret);
                BoolToByte = (Func<bool, byte>)methodBoolToByte.CreateDelegate(typeof(Func<bool, byte>));
            }
        }
    }
