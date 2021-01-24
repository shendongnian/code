    using System;
    using System.Runtime.InteropServices;
    
    namespace COMInterop {
        public class Ole32Methods {
            [DllImport("ole32.Dll")]
            static public extern int CoCreateInstance(ref Guid clsid, [MarshalAs(UnmanagedType.IUnknown)] object inner, uint context, ref Guid uuid, [Out, MarshalAs(UnmanagedType.IUnknown)] out object rReturnedComObject);
            public static uint CLSCTX_INPROC_SERVER = 1;
        }
    }
    
    namespace Interops {
    
        public abstract class INetCfgGuid {
            public static Guid CLSID_CNetCfg = new Guid("5B035261-40F9-11D1-AAEC-00805FC1270E");
            public static Guid IID_INetCfg = new Guid("C0E8AE93-306E-11D1-AACF-00805FC1270E");
            public static Guid IID_INetCfgLock = new Guid("C0E8AE9F-306E-11D1-AACF-00805FC1270E");
            public static Guid IID_INetCfgClass = new Guid("C0E8AE97-306E-11D1-AACF-00805FC1270E");
            public static Guid IID_INetCfgComponentBindings = new Guid("C0E8AE9E-306E-11D1-AACF-00805FC1270E");
    
            public static Guid IID_DevClassNet = new Guid(0x4d36e972, 0xe325, 0x11ce, 0xbf, 0xc1, 0x08, 0x00, 0x2b, 0xe1, 0x03, 0x18);  // Network adapters
            public static Guid IID_DevClassNetClient = new Guid(0x4d36e973, 0xe325, 0x11ce, 0xbf, 0xc1, 0x08, 0x00, 0x2b, 0xe1, 0x03, 0x18); // Deprecated
            public static Guid IID_DevClassNetService = new Guid(0x4d36e974, 0xe325, 0x11ce, 0xbf, 0xc1, 0x08, 0x00, 0x2b, 0xe1, 0x03, 0x18); // 
            public static Guid IID_DevClassNetTrans = new Guid(0x4d36e975, 0xe325, 0x11ce, 0xbf, 0xc1, 0x08, 0x00, 0x2b, 0xe1, 0x03, 0x18);   // Protocols
        }
    
        // ----  Enums ------ //
        enum COMPONENT_CHARACTERISTICS {
            NCF_VIRTUAL = 0x00000001,
            NCF_SOFTWARE_ENUMERATED = 0x00000002,
            NCF_PHYSICAL = 0x00000004,
            NCF_HIDDEN = 0x00000008,
            NCF_NO_SERVICE = 0x00000010,
            NCF_NOT_USER_REMOVABLE = 0x00000020,
            NCF_MULTIPORT_INSTANCED_ADAPTER = 0x00000040, // This adapter has separate instances for each port 
            NCF_HAS_UI = 0x00000080,
            NCF_SINGLE_INSTANCE = 0x00000100,
            // = 0x00000200, // filter device 
            NCF_FILTER = 0x00000400, // filter component 
            NCF_DONTEXPOSELOWER = 0x00001000,
            NCF_HIDE_BINDING = 0x00002000, // don't show in binding page 
            NCF_NDIS_PROTOCOL = 0x00004000, // Needs UNLOAD notifications 
            // = 0x00008000, 
            // = 0x00010000, // pnp notifications forced through service controller 
            NCF_FIXED_BINDING = 0x00020000 // UI ability to change binding is disabled 
        }
    
        enum NCRP_FLAGS {
            NCRP_QUERY_PROPERTY_UI = 0x00000001,
            NCRP_SHOW_PROPERTY_UI = 0x00000002
        }
    
        enum SUPPORTS_BINDING_INTERFACE_FLAGS {
            NCF_LOWER = 0x01,
            NCF_UPPER = 0x02
        };
    
        enum ENUM_BINDING_PATHS_FLAGS {
            EBP_ABOVE = 0x01,
            EBP_BELOW = 0x02,
        };
    
        enum OBO_TOKEN_TYPE {
            OBO_USER = 1,
            OBO_COMPONENT = 2,
            OBO_SOFTWARE = 3,
        };
        
        // ----- Structs -----//
    
        struct OBO_TOKEN {
            [MarshalAs(UnmanagedType.I4)]
            OBO_TOKEN_TYPE Type;
    
            // Type == OBO_COMPONENT 
            //
            INetCfgComponent pncc;
    
            // Type == OBO_SOFTWARE 
            // 
            [MarshalAs(UnmanagedType.LPWStr)]
            string pszwManufacturer;
            [MarshalAs(UnmanagedType.LPWStr)]
            string pszwProduct;
            [MarshalAs(UnmanagedType.LPWStr)]
            string pszwDisplayName;
    
            // The following fields must be initialized to zero 
            // by users of OBO_TOKEN. 
            // 
            [MarshalAs(UnmanagedType.Bool)]
            bool fRegistered;
        };
    
        // --------- Enumerations ----------//
        [Guid("C0E8AE90-306E-11D1-AACF-00805FC1270E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComVisible(true)]
        public interface IEnumNetCfgBindingInterface {
            int Next([In, MarshalAs(UnmanagedType.U4)] int celt, out INetCfgBindingInterface rgelt, [Out, MarshalAs(UnmanagedType.U4)] out int pceltFetched);
    
            int Skip([In, MarshalAs(UnmanagedType.U4)] int celt);
            int Reset();
            int Clone(out IEnumNetCfgBindingInterface ppenum);
        }
    
        [Guid("C0E8AE91-306E-11D1-AACF-00805FC1270E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComVisible(true)]
        interface IEnumNetCfgBindingPath {
            int Next([In, MarshalAs(UnmanagedType.U4)] int celt, out INetCfgBindingPath rgelt, [Out, MarshalAs(UnmanagedType.U4)] out int pceltFetched);
    
            int Skip([In, MarshalAs(UnmanagedType.U4)] int celt);
            int Reset();
            int Clone(out IEnumNetCfgBindingPath ppenum);
        }
    
        [Guid("C0E8AE92-306E-11D1-AACF-00805FC1270E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComVisible(true)]
        interface IEnumNetCfgComponent {
            int Next([In, MarshalAs(UnmanagedType.U4)] int celt, out INetCfgComponent rgelt, [Out, MarshalAs(UnmanagedType.U4)] out int pceltFetched);
            int Skip([In, MarshalAs(UnmanagedType.U4)] int celt);
            int Reset();
            int Clone(out IEnumNetCfgComponent ppenum);
        };
    
        // ------- Classes -------//
    
        [Guid("C0E8AE93-306E-11D1-AACF-00805FC1270E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComVisible(true)]
        interface INetCfg {
            int Initialize(IntPtr pvReserved);
            int Uninitialize();
            int Apply();
            int Cancel();
            int EnumComponents(IntPtr pguidClass, out IEnumNetCfgComponent ppenumComponent);
            int FindComponent([In, MarshalAs(UnmanagedType.LPWStr)]  string pszwInfId, out INetCfgComponent pComponent);
            int QueryNetCfgClass([In]ref Guid pguidClass, ref Guid riid, [Out, MarshalAs(UnmanagedType.IUnknown)] out object ppvObject);
        };
    
        [Guid("C0E8AE9F-306E-11D1-AACF-00805FC1270E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComVisible(true)]
        internal interface INetCfgLock {
            int AcquireWriteLock([In, MarshalAs(UnmanagedType.U4)] uint cmsTimeout, [In, MarshalAs(UnmanagedType.LPWStr)] string pszwClientDescription, [In, Out, MarshalAs(UnmanagedType.LPWStr)] ref string ppszwClientDescription);
            int ReleaseWriteLock();
            int IsWriteLocked([Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszwClientDescription);
        }
    
        [Guid("C0E8AE94-306E-11D1-AACF-00805FC1270E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComVisible(true)]
        public interface INetCfgBindingInterface {
            int GetName([Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszwInterfaceName);
            int GetUpperComponent(out INetCfgComponent ppnccItem);
            int GetLowerComponent(out INetCfgComponent ppnccItem);
        };
    
        [Guid("C0E8AE96-306E-11D1-AACF-00805FC1270E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComVisible(true)]
        interface INetCfgBindingPath {
            int IsSamePathAs([In, MarshalAs(UnmanagedType.IUnknown)] /*INetCfgBindingPath*/ object pPath);
            int IsSubPathOf([In, MarshalAs(UnmanagedType.IUnknown)] /*INetCfgBindingPath*/ object pPath);
            int IsEnabled();
            int Enable([MarshalAs(UnmanagedType.Bool)]bool fEnable);
            int GetPathToken([Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszwPathToken);
            int GetOwner([Out, MarshalAs(UnmanagedType.IUnknown)] out INetCfgBindingPath ppComponent);
            int GetDepth([Out, MarshalAs(UnmanagedType.U4)] out int pcInterfaces);
            int EnumBindingInterfaces(out IEnumNetCfgBindingInterface ppenumInterface);
        };
    
        [Guid("C0E8AE99-306E-11D1-AACF-00805FC1270E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComVisible(true)]
        public interface INetCfgComponent {
    
            int GetDisplayName([Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszwDisplayName);
            int SetDisplayName([In, MarshalAs(UnmanagedType.LPWStr)] string pszwDisplayName);
            int GetHelpText([Out, MarshalAs(UnmanagedType.LPWStr)] out string pszwHelpText);
            int GetId([Out, MarshalAs(UnmanagedType.LPWStr)]out string ppszwId);
            int GetCharacteristics([Out, MarshalAs(UnmanagedType.U4)] out int pdwCharacteristics);
            int GetInstanceGuid([Out] Guid pGuid);
            int GetPnpDevNodeId([Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszwDevNodeId);
            int GetClassGuid([Out]  Guid pGuid);
            int GetBindName([Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszwBindName);
            int GetDeviceStatus([Out, MarshalAs(UnmanagedType.U4)] out int pulStatus);
            int OpenParamKey([Out, MarshalAs(UnmanagedType.U4)] IntPtr phkey);
            int RaisePropertyUi([In] IntPtr hwndParent, [In, MarshalAs(UnmanagedType.U4)] int dwFlags /* NCRP_FLAGS */, [In, MarshalAs(UnmanagedType.IUnknown)] object punkContext);
        };
    
        [Guid("C0E8AE97-306E-11D1-AACF-00805FC1270E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComVisible(true)]
        interface INetCfgClass {
            int FindComponent([In, MarshalAs(UnmanagedType.LPWStr)] string pszwInfId, out INetCfgComponent ppnccItem);
            int EnumComponents(out IEnumNetCfgComponent ppenumComponent);
        };
    
        [Guid("C0E8AE9D-306E-11D1-AACF-00805FC1270E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComVisible(true)]
        interface INetCfgClassSetup {
            int SelectAndInstall([In] IntPtr hwndParent, [In] /*OBO_TOKEN*/IntPtr pOboToken, out INetCfgComponent ppnccItem);
    
            int Install([In, MarshalAs(UnmanagedType.LPWStr)] string pszwInfId, [In] /*OBO_TOKEN*/IntPtr pOboToken, [In, MarshalAs(UnmanagedType.U4)] int dwSetupFlags, [In, MarshalAs(UnmanagedType.U4)] int dwUpgradeFromBuildNo,
                [In, MarshalAs(UnmanagedType.LPWStr)] string pszwAnswerFile, [In, MarshalAs(UnmanagedType.LPWStr)] string pszwAnswerSections, out INetCfgComponent ppnccItem);
    
            int DeInstall(INetCfgComponent pComponent, [In] /*OBO_TOKEN*/IntPtr pOboToken, [Out, MarshalAs(UnmanagedType.LPWStr)] out string pmszwRefs);
        };
    
        [Guid("C0E8AE9E-306E-11D1-AACF-00805FC1270E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComVisible(true)]
        interface INetCfgComponentBindings {
    
            int BindTo(INetCfgComponent pnccItem);
    
            int UnbindFrom(INetCfgComponent pnccItem);
    
            int SupportsBindingInterface([In, MarshalAs(UnmanagedType.U4)] int dwFlags, [In, MarshalAs(UnmanagedType.LPWStr)] string pszwInterfaceName);
    
            int IsBoundTo(INetCfgComponent pnccItem);
    
            int IsBindableTo(INetCfgComponent pnccItem);
    
            int EnumBindingPaths([In, MarshalAs(UnmanagedType.U4)] int dwFlags, out IEnumNetCfgBindingPath ppIEnum);
    
            int MoveBefore(INetCfgBindingPath pncbItemSrc, INetCfgBindingPath pncbItemDest);
    
            int MoveAfter(INetCfgBindingPath pncbItemSrc, INetCfgBindingPath pncbItemDest);
        };
    
        [Guid("C0E8AE98-306E-11D1-AACF-00805FC1270E"),InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComVisible(true)]
        interface INetCfgSysPrep {
            int HrSetupSetFirstDword([In, MarshalAs(UnmanagedType.LPWStr)] string pwszSection, [In, MarshalAs(UnmanagedType.LPWStr)] string pwszKey, [In, MarshalAs(UnmanagedType.U4)] int dwValue);
    
            int HrSetupSetFirstString([In, MarshalAs(UnmanagedType.LPWStr)] string pwszSection, [In, MarshalAs(UnmanagedType.LPWStr)] string pwszKey, [In, MarshalAs(UnmanagedType.LPWStr)] string pwszValue);
    
            int HrSetupSetFirstStringAsBool([In, MarshalAs(UnmanagedType.LPWStr)] string pwszSection, [In, MarshalAs(UnmanagedType.LPWStr)] string pwszKey, [MarshalAs(UnmanagedType.Bool)] bool fValue);
    
            int HrSetupSetFirstMultiSzField([In, MarshalAs(UnmanagedType.LPWStr)] string pwszSection, [In, MarshalAs(UnmanagedType.LPWStr)] string pwszKey, [In, MarshalAs(UnmanagedType.LPWStr)] string pmszValue);
        };
    }
