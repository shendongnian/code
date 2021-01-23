    // Delphi
    library test;
    
    uses
      SysUtils;
    
    {$R *.res}
    
    type
      TCallback = procedure (P: PChar); stdcall;
      TMethodCallback = procedure (P: PChar) of object; stdcall;
    
    procedure DllTest1(Callback: TCallback; P: PChar; I: Integer); stdcall;
    var
      S: string;
    begin
      S := Format('DllTest1 ''%s'' %d', [P, I]);
      if Assigned(Callback) then
        Callback(PChar(S));
    end;
    
    procedure DllTest2(_Callback: Pointer; P: PChar; I: Integer); stdcall;
    var
      Callback: TMethodCallback absolute _Callback;
      S: string;
    begin
      S := Format('DllTest2 ''%s'' %d', [P, I]);
      if Assigned(Callback) then
        Callback(PChar(S));
    end;
    
    procedure DllTest3(Callback: TMethodCallback; P: PChar; I: Integer); stdcall;
    var
      S: string;
    begin
      S := Format('DllTest3 ''%s'' %d', [P, I]);
      if Assigned(Callback) then
        Callback(PChar(S));
    end;
    
    exports
      DllTest1,
      DllTest2,
      DllTest3;
    
    begin
    end.
    
    // C#
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.InteropServices;
    
    namespace DllTest
    {
        class Program
        {
            public struct Method
            {
                public IntPtr code;
                public IntPtr data;
            }
            [DllImport("Test.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "DllTest1")]
            public static extern void DllTest1(IntPtr p, [MarshalAs(UnmanagedType.LPStr)] string s, int i);
            [DllImport("Test.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "DllTest2")]
            public static extern void DllTest2(IntPtr p, [MarshalAs(UnmanagedType.LPStr)] string s, int i);
            [DllImport("Test.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "DllTest3")]
            public static extern void DllTest3(Method m, [MarshalAs(UnmanagedType.LPStr)] string s, int i);
    
            public delegate void Callback([MarshalAs(UnmanagedType.LPStr)] string s);
            public delegate void MethodCallback(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string s);
            public static void ShowInfo(string s)
            {
                Console.WriteLine("Info: " + s);
            }
            public static void ShowMethodInfo(IntPtr self, string s)
            {
                Console.WriteLine("Info: " + s);
            }
    
    
            static void Main(string[] args)
            {
                Method m;
                Callback info = ShowInfo;
                MethodCallback methodInfo = ShowMethodInfo;
                IntPtr p = Marshal.GetFunctionPointerForDelegate(info);
                IntPtr pm = Marshal.GetFunctionPointerForDelegate(methodInfo);
    
                // function callback example
                DllTest1(p, "test", 42);
                // method callback example 1
                DllTest2(pm, "test", 42);
                // method callback example 2
                m.code = pm;
                m.data = IntPtr.Zero;
                DllTest3(m, "test", 42);
            }
        }
    }
