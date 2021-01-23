    using System;
    using System.Runtime.InteropServices;
    using Microsoft.Office.Interop.Excel;
    using Microsoft.Win32;
    using System.Text.RegularExpressions;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace myUDF
    {
        [ClassInterface(ClassInterfaceType.AutoDual)]
        [ComVisible(true)]
        public class Functions
        {
            public Functions()
            {
            }
    
            //ADD your Functions
            public bool IsFoo(string str)
           {
               return (str == "foo");
            }
    
            //Must Add Code
            [ComRegisterFunctionAttribute]
            public static void RegisterFunction(Type type)
            {
    
                Registry.ClassesRoot.CreateSubKey(GetSubKeyName(type, "Programmable"));
                RegistryKey key = Registry.ClassesRoot.OpenSubKey(GetSubKeyName(type, "InprocServer32"), true);
                key.SetValue("", System.Environment.SystemDirectory + @"\mscoree.dll", RegistryValueKind.String);
            }
    
            [ComUnregisterFunctionAttribute]
            public static void UnregisterFunction(Type type)
            {
                Registry.ClassesRoot.DeleteSubKey(GetSubKeyName(type, "Programmable"), false);
            }
    
            private static string GetSubKeyName(Type type,
    
            string subKeyName)
            {
                System.Text.StringBuilder s = new System.Text.StringBuilder();
                s.Append(@"CLSID\{");
                s.Append(type.GUID.ToString().ToUpper());
                s.Append(@"}\");
                s.Append(subKeyName);
                return s.ToString();
            }
        }
    }
