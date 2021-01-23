    using System;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.Reflection;
    using System.Runtime.InteropServices.CustomMarshalers;
    namespace ConsoleApplication1
    {
        [
           ComImport,
           Guid("00020400-0000-0000-C000-000000000046"),
           InterfaceType(ComInterfaceType.InterfaceIsIUnknown)
        ]
        public interface IDispatch
        {
            void Reserved();
            [PreserveSig]
            int GetTypeInfo(uint nInfo, int lcid,
               [MarshalAs(
                  UnmanagedType.CustomMarshaler,
                  MarshalTypeRef = typeof(TypeToTypeInfoMarshaler))]
               out System.Type typeInfo);
        }
        class Program
        {
            static void Main(string[] args)
            {
                Type t1 = Type.GetTypeFromProgID("WbemScripting.SWbemDateTime");
                Object o1 = Activator.CreateInstance(t1);
                IDispatch disp2 = o1 as IDispatch;
                if (disp2 != null)
                {
                    Type t3;
                    disp2.GetTypeInfo(0, 0, out t3);
                    MemberInfo[] mlist3 = t3.GetMembers();
                }
            }
        }
    }
