    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices.ComTypes;
    using Microsoft.Win32;
    using System.Windows.Forms;
    
    namespace TestShell
    {
      [ComImport]
      [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
      [Guid("b7d14566-0509-4cce-a71f-0a554233bd9b")]
      interface IInitializeWithFile
      {
        [PreserveSig]
        int Initialize([MarshalAs(UnmanagedType.LPWStr)] string pszFilePath, uint grfMode);
      }
    
      [StructLayout(LayoutKind.Sequential)]
      public struct PROPERTYKEY
      {
        public Guid fmtid;
        public UIntPtr pid;
      }
    
      [ComImport]
      [Guid("c8e2d566-186e-4d49-bf41-6909ead56acc")]
      [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
      interface IPropertyStoreCapabilities
      {
        [PreserveSig]
        int IsPropertyWritable([In] ref PROPERTYKEY key);
      }
    
      [ComImport]
      [Guid("886D8EEB-8CF2-4446-8D02-CDBA1DBDCF99")]
      [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
      interface IPropertyStore
      {
        [PreserveSig]
        int GetCount([Out] out uint cProps);
        [PreserveSig]
        int GetAt([In] uint iProp, out PROPERTYKEY pkey);
        [PreserveSig]
        int GetValue([In] ref PROPERTYKEY key, out PropVariant pv);
        [PreserveSig]
        int SetValue([In] ref PROPERTYKEY key, [In] ref object pv);
        [PreserveSig]
        int Commit();
      }
    
      [StructLayout(LayoutKind.Sequential)]
      public struct PropVariant
      {
        public short variantType;
        public short Reserved1, Reserved2, Reserved3;
        public IntPtr pointerValue;
      }
    
    
      [ComVisible(true)]
      [ClassInterface(ClassInterfaceType.None)]
      [ProgId("TestShell.PropertyHandler")]
      [Guid("9BC59AF4-41E3-49B1-9A62-17F4C92D081F")]
      public class PropertyHandler : IInitializeWithFile, IPropertyStore, IPropertyStoreCapabilities
      {
        private const int S_OK = 0, S_FALSE = 1;
    
        private string path = null;
    
    
        public int Initialize(string pszFilePath, uint grfMode)
        {
          //System.Windows.Forms.MessageBox.Show(pszFilePath);
          path = pszFilePath;
          return S_OK;
        }
    
        public int IsPropertyWritable(ref PROPERTYKEY key)
        {
          //System.Windows.Forms.MessageBox.Show("Writable");
          return S_OK;
        }
    
        public int GetCount(out uint cProps)
        {
          //System.Windows.Forms.MessageBox.Show("GetCount");
          cProps = 1;
          return S_OK;
        }
    
        public int GetAt(uint iProp, out PROPERTYKEY pkey)
        {
          System.Windows.Forms.MessageBox.Show(iProp.ToString());
          pkey = new PROPERTYKEY();
          pkey.fmtid = PKEY_Title;
          pkey.pid = (UIntPtr)0x2;
          return S_OK;
        }
    
        private Guid PKEY_Title = new Guid("F29F85E0-4FF9-1068-AB91-08002B27B3D9");
    
        public int GetValue(ref PROPERTYKEY key, out PropVariant pv)
        {
          System.Windows.Forms.MessageBox.Show(key.fmtid.ToString());
          pv = new PropVariant();
          if (key.fmtid == PKEY_Title)
          {
            pv.variantType = 31;
            pv.pointerValue = Marshal.StringToHGlobalUni("Test");
            return S_OK;
          }
          else
          {
            pv.variantType = 0;	//VT_EMPTY
            pv.pointerValue = IntPtr.Zero;
            return S_OK;
          }
        }
    
        public int SetValue(ref PROPERTYKEY key, ref object pv)
        {
          return S_OK;
        }
    
        public int Commit()
        {
          return S_OK;
        }
    
        
    
        [ComRegisterFunctionAttribute]
        public static void RegisterFunction(Type t)
        {
          
          try
          {
            RegistryKey regHKCR = Registry.ClassesRoot;
            regHKCR = regHKCR.CreateSubKey(".test");
            regHKCR.SetValue(null, "TestShell.PropertyHandler");
    
            regHKCR = Registry.ClassesRoot;
            regHKCR = regHKCR.CreateSubKey("CLSID\\{9BC59AF4-41E3-49B1-9A62-17F4C92D081F}");
            regHKCR.SetValue(null, "Test Property");
            regHKCR.SetValue("ManualSafeSave", 1);
            regHKCR.SetValue("Title", 2);
            regHKCR.SetValue("Whatever", 3);
            regHKCR = regHKCR.CreateSubKey("InProcServer32");
            
            regHKCR.SetValue(null, @"C:\Windows\System32\mscoree.dll");
            //regHKCR.SetValue(null, System.Reflection.Assembly.GetExecutingAssembly().Location);
            regHKCR.SetValue("ThreadingModel", "Apartment");
    
            RegistryKey regHKLM;
            regHKLM = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\PropertySystem\\PropertyHandlers\\.test");
            regHKLM.SetValue(null, "{9BC59AF4-41E3-49B1-9A62-17F4C92D081F}");
            regHKLM = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Shell Extensions\\Approved");
            regHKLM.SetValue("{9BC59AF4-41E3-49B1-9A62-17F4C92D081F}", "Test Property");
            //SHShellRestart();---------------------------------------------------------------------------------------------
    
            // string propertyID = "VolumeName";
            // //PROPSPEC propSpec = new PROPSPEC();
            // //propSpec.ulKind = 0;
            //// propSpec.__unnamed.lpwstr = (char*)Marshal.StringToCoTaskMemUni(propertyID);
     
            // PropVariant propVar = new PropVariant();
            // propVar.__unnamed.__unnamed.__unnamed.bstrVal = (char*)Marshal.StringToCoTaskMemUni(value);
            
            //   //delcare un safe variables
            //   PROPSPEC[] rgSpecs = new PROPSPEC[1];
            //   rgSpecs[0] = propSpec;
     
            //   PROPVARIANT[] rgVar = new PROPVARIANT[1];
            //   rgVar[0] = propVar;
     
            //   object val = value;
            //   ppPropStg.WriteMultiple(1, ref propSpec, ref val, 3);
            //   ppPropStg.Commit(0x8);
            //   fDataDiscWriter.SetJolietProperties(ppPropStg);
           
          }
        
     	
    
           
          catch (Exception ex)//HKEY_CLASSES_ROOT\CLSID\{9BC59AF4-41E3-49B1-9A62-17F4C92D081F}\Implemented Categories\{62C8FE65-4EBB-45e7-B440-6E39B2CDBF29}
          {
    #if DEBUG
            System.Windows.Forms.MessageBox.Show(ex.Message + System.Environment.NewLine + ex.StackTrace);
    #endif
          }
    #if DEBUG
          //SHShellRestart();
    #endif
        }
    
        [ComUnregisterFunctionAttribute]
        public static void UnRegisterFunction(Type t)
        {
          try
          {
            RegistryKey regHKCR = Registry.ClassesRoot;
            regHKCR.DeleteSubKey(".test");
            regHKCR.DeleteSubKeyTree("CLSID\\{9BC59AF4-41E3-49B1-9A62-17F4C92D081F}");
    
            RegistryKey regHKLM = Registry.LocalMachine;
            regHKLM.DeleteSubKeyTree("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\PropertySystem\\PropertyHandlers\\.test");
            regHKLM = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Shell Extensions\\Approved", true);
            regHKLM.DeleteValue("{9BC59AF4-41E3-49B1-9A62-17F4C92D081F}");
          }
          catch (Exception ex)
          {
    #if DEBUG
            System.Windows.Forms.MessageBox.Show(ex.Message + System.Environment.NewLine + ex.StackTrace);
    #endif
          }
    #if DEBUG
          //SHShellRestart();
    #endif
        }
    
    //#if DEBUG
        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("shell32.dll")]
        static extern IntPtr ShellExecute(
          IntPtr hwnd, string lpOperation, string lpFile,
          string lpParameters, string lpDirectory, int nShowCmd);
        private static void SHShellRestart()
        {
          PostMessage(FindWindow("Progman", null), 0x0012, IntPtr.Zero, IntPtr.Zero);
          ShellExecute(IntPtr.Zero, null, "explorer.exe", null, null, 5);
          return;
        }
    //#endif
      }
    }
