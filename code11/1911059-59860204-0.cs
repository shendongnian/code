    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace TestConsApp
    {
        internal static class Program
        {
            [DllImport(dllName: "TestFortran.dll", CallingConvention = CallingConvention.Cdecl)]
            internal unsafe static extern void TestCallBack([MarshalAs(UnmanagedType.FunctionPtr)] ActionRefInt callBack);
    
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void ActionRefInt(ref int i);
    
    
            private static void Main(string[] args)
            {
                TestCallBack();
                Console.ReadLine();
            }
    
            private static void TestCallBack()
            {
                var callbackHandler = new ActionRefInt(OnCallBackInt);
                TestCallBack(callbackHandler);
            }
    
            private static void OnCallBackInt(ref int i)
            {
                Console.WriteLine($"C#: Value before change: {i}");
                i++;
                Console.WriteLine($"C#: Value after change: {i}");
            }
    
        }
    }
