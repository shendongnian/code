    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using System.Collections.Generic;
    
    namespace TravelLogUtils
    {
        [ComVisible(true), ComImport()]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [GuidAttribute("7EBFDD87-AD18-11d3-A4C5-00C04F72D6B8")]
        public interface ITravelLogEntry
        {
            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int GetTitle([Out] out IntPtr ppszTitle); //LPOLESTR LPWSTR
    
            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int GetURL([Out] out IntPtr ppszURL); //LPOLESTR LPWSTR
        }
    
        [ComVisible(true), ComImport()]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [GuidAttribute("7EBFDD85-AD18-11d3-A4C5-00C04F72D6B8")]
        public interface IEnumTravelLogEntry
        {
            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int Next(
                [In, MarshalAs(UnmanagedType.U4)] int celt,
                [Out] out ITravelLogEntry rgelt,
                [Out, MarshalAs(UnmanagedType.U4)] out int pceltFetched);
    
            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int Skip([In, MarshalAs(UnmanagedType.U4)] int celt);
    
            void Reset();
    
            void Clone([Out] out ITravelLogEntry ppenum);
        }
    
        public enum TLMENUF
        {
            /// <summary>
            /// Enumeration should include the current travel log entry.
            /// </summary>
            TLEF_RELATIVE_INCLUDE_CURRENT = 0x00000001,
            /// <summary>
            /// Enumeration should include entries before the current entry.
            /// </summary>
            TLEF_RELATIVE_BACK = 0x00000010,
            /// <summary>
            /// Enumeration should include entries after the current entry.
            /// </summary>
            TLEF_RELATIVE_FORE = 0x00000020,
            /// <summary>
            /// Enumeration should include entries which cannot be navigated to.
            /// </summary>
            TLEF_INCLUDE_UNINVOKEABLE = 0x00000040,
            /// <summary>
            /// Enumeration should include all invokable entries.
            /// </summary>
            TLEF_ABSOLUTE = 0x00000031
        }
    
        [ComVisible(true), ComImport()]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [GuidAttribute("7EBFDD80-AD18-11d3-A4C5-00C04F72D6B8")]
        public interface ITravelLogStg
        {
            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int CreateEntry([In, MarshalAs(UnmanagedType.LPWStr)] string pszUrl,
                [In, MarshalAs(UnmanagedType.LPWStr)] string pszTitle,
                [In] ITravelLogEntry ptleRelativeTo,
                [In, MarshalAs(UnmanagedType.Bool)] bool fPrepend,
                [Out] out ITravelLogEntry pptle);
    
            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int TravelTo([In] ITravelLogEntry ptle);
    
            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int EnumEntries([In] int TLENUMF_flags, [Out] out IEnumTravelLogEntry ppenum);
    
            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int FindEntries([In] int TLENUMF_flags,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszUrl,
            [Out] out IEnumTravelLogEntry ppenum);
    
            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int GetCount([In] int TLENUMF_flags, [Out] out int pcEntries);
    
            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int RemoveEntry([In] ITravelLogEntry ptle);
    
            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int GetRelativeEntry([In] int iOffset, [Out] out ITravelLogEntry ptle);
        }
    
        [ComImport, ComVisible(true)]
        [Guid("6d5140c1-7436-11ce-8034-00aa006009fa")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IServiceProvider
        {
            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int QueryService(
                [In] ref Guid guidService,
                [In] ref Guid riid,
                [Out] out IntPtr ppvObject);
        }
    
        public class TravelLog
        {
            public static Guid IID_ITravelLogStg = new Guid("7EBFDD80-AD18-11d3-A4C5-00C04F72D6B8");
            public static Guid SID_STravelLogCursor = new Guid("7EBFDD80-AD18-11d3-A4C5-00C04F72D6B8");
    
            //public static void TravelTo(WebBrowser webBrowser, int 
            public static ITravelLogEntry GetTravelLogEntry(WebBrowser webBrowser)
            {
                int HRESULT_OK = 0;
                
                SHDocVw.IWebBrowser2 axWebBrowser = (SHDocVw.IWebBrowser2)webBrowser.ActiveXInstance;
                IServiceProvider psp = axWebBrowser as IServiceProvider;
                if (psp == null) throw new Exception("Could not get IServiceProvider.");
    
                IntPtr oret = IntPtr.Zero;            
                int hr = psp.QueryService(ref SID_STravelLogCursor, ref IID_ITravelLogStg, out oret);            
                if ((oret == IntPtr.Zero) || (hr != HRESULT_OK)) throw new Exception("Failed to query service.");
    
                ITravelLogStg tlstg = Marshal.GetObjectForIUnknown(oret) as ITravelLogStg;
                if (null == tlstg) throw new Exception("Failed to get ITravelLogStg");            
                ITravelLogEntry ptle = null;
    
                hr = tlstg.GetRelativeEntry(0, out ptle);
    
                if (hr != HRESULT_OK) throw new Exception("Failed to get travel log entry with error " + hr.ToString("X"));
    
                Marshal.ReleaseComObject(tlstg);
                return ptle;
            }
    
            public static void TravelToTravelLogEntry(WebBrowser webBrowser, ITravelLogEntry travelLogEntry)
            {
                int HRESULT_OK = 0;
    
                SHDocVw.IWebBrowser2 axWebBrowser = (SHDocVw.IWebBrowser2)webBrowser.ActiveXInstance;
                IServiceProvider psp = axWebBrowser as IServiceProvider;
                if (psp == null) throw new Exception("Could not get IServiceProvider.");
    
                IntPtr oret = IntPtr.Zero;
                int hr = psp.QueryService(ref SID_STravelLogCursor, ref IID_ITravelLogStg, out oret);
                if ((oret == IntPtr.Zero) || (hr != HRESULT_OK)) throw new Exception("Failed to query service.");
    
                ITravelLogStg tlstg = Marshal.GetObjectForIUnknown(oret) as ITravelLogStg;
                if (null == tlstg) throw new Exception("Failed to get ITravelLogStg");
                
                hr = tlstg.TravelTo(travelLogEntry);
    
                if (hr != HRESULT_OK) throw new Exception("Failed to travel to log entry with error " + hr.ToString("X"));
    
                Marshal.ReleaseComObject(tlstg);
            }
            public static HashSet<ITravelLogEntry> GetTravelLogEntries(WebBrowser webBrowser)
            {
                int HRESULT_OK = 0;
                SHDocVw.IWebBrowser2 axWebBrowser = (SHDocVw.IWebBrowser2)webBrowser.ActiveXInstance;
                IServiceProvider psp = axWebBrowser as IServiceProvider;
                if (psp == null) throw new Exception("Could not get IServiceProvider.");
                IntPtr oret = IntPtr.Zero;
                int hr = psp.QueryService(ref SID_STravelLogCursor, ref IID_ITravelLogStg, out oret);
                if ((oret == IntPtr.Zero) || (hr != HRESULT_OK)) throw new Exception("Failed to query service.");
                ITravelLogStg tlstg = Marshal.GetObjectForIUnknown(oret) as ITravelLogStg;
                if (null == tlstg) throw new Exception("Failed to get ITravelLogStg");
                //Enum the travel log entries
                IEnumTravelLogEntry penumtle = null;
                tlstg.EnumEntries((int)TLMENUF.TLEF_ABSOLUTE, out penumtle);
                hr = 0;
                ITravelLogEntry ptle = null;
                int fetched = 0;
                const int MAX_FETCH_COUNT = 1;
                hr = penumtle.Next(MAX_FETCH_COUNT, out ptle, out fetched);
                Marshal.ThrowExceptionForHR(hr);
                HashSet<ITravelLogEntry> results = new HashSet<ITravelLogEntry>();
                for (int i = 0; 0 == hr; i++)
                {
                    if (ptle != null) results.Add(ptle);
                    hr = penumtle.Next(MAX_FETCH_COUNT, out ptle, out fetched);
                    Marshal.ThrowExceptionForHR(hr);
                }
                Marshal.ReleaseComObject(penumtle);
                Marshal.ReleaseComObject(tlstg);
                return results;
            }
        }
    }
