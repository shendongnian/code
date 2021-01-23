    using System;
    using System.Runtime.InteropServices;
    
    class Program {
        static void Main(string[] args) {
            Foo value = GetFoo();
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct Foo {
            public int a;
            public byte b;
            public int c;
        };
        [DllImport(@"c:\projects\consoleapplication3\debug\cpptemp10.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "_GetFoo@0")]
        private static extern Foo GetFoo(/*int CoreIndex*/);
    }
----------
    typedef struct foo  
    {  
        int  a;  
        bool b;
        int  c;  
    } FOO,*LPFOO;
    
    extern "C" __declspec(dllexport) 
    FOO __stdcall GetFoo()  
    {  
        FOO f;  
        f.a = 42;
        f.b = true;
        f.c = 101;
        return f;   
    }  
