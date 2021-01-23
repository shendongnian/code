    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Linq;
    using System.Windows.Forms;
    using Rdp.Interfaces;
    using Microsoft.Win32;
    using System.ServiceProcess;
    using System.Diagnostics;
    using System.Threading;
    using Balzers.Misc.Helpers;
    namespace Rdp.Service {
    /// <summary>
    /// 	<para> Terminal session info provider has 2 main functions:</para>
    /// 	<list type="number">
    /// 		<item>
    /// 			<description>Provide all current terminal session information: <see cref="M:Oerlikon.Balzers.Rdp.Service.RdpSessionInfo.ListSessions(System.Boolean)"/></description>
    /// 		</item>
    /// 		<item>
    /// 			<description>Observer terminal session changes: <see cref="E:Oerlikon.Balzers.Rdp.Service.RdpSessionInfo.SessionChanged"/></description>
    /// 		</item>
    /// 	</list>
    /// </summary>
    public class RdpSessionInfo : IDisposable {
        /************************************************************************************************/
        /*                                  DllImports                                                  */
        /************************************************************************************************/
        #region DllImports
        [DllImport("wtsapi32.dll", SetLastError = true)]
        static extern IntPtr WTSOpenServer([MarshalAs(UnmanagedType.LPStr)] String pServerName);
        [DllImport("wtsapi32.dll")]
        static extern void WTSCloseServer(IntPtr hServer);
        [DllImport("wtsapi32.dll")]
        static extern int WTSEnumerateSessions(
            IntPtr pServer,
            [MarshalAs(UnmanagedType.U4)] int iReserved,
            [MarshalAs(UnmanagedType.U4)] int iVersion,
            ref IntPtr pSessionInfo,
            [MarshalAs(UnmanagedType.U4)] ref int iCount);
        [DllImport("Wtsapi32.dll")]
        static extern bool WTSQuerySessionInformation(
            System.IntPtr pServer,
            int iSessionID,
            WTS_INFO_CLASS oInfoClass,
            out System.IntPtr pBuffer,
            out uint iBytesReturned);
        [DllImport("Wtsapi32.dll")]
        public static extern bool WTSWaitSystemEvent(
            IntPtr hServer,
            UInt32 EventMask,
            out IntPtr pEventFlags);
        [DllImport("wtsapi32.dll")]
        static extern void WTSFreeMemory(IntPtr pMemory);
        [DllImport("user32.dll")]
        public static extern int ExitWindowsEx(int uFlags, int dwReason);
        [DllImport("WtsApi32.dll")]
        private static extern bool WTSRegisterSessionNotification(IntPtr hWnd, [MarshalAs(UnmanagedType.U4)]int dwFlags);
        [DllImport("WtsApi32.dll")]
        private static extern bool WTSUnRegisterSessionNotification(IntPtr hWnd);
        public delegate int ServiceControlHandlerEx(int control, int eventType, IntPtr eventData, IntPtr context);
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern IntPtr RegisterServiceCtrlHandlerEx(string lpServiceName, ServiceControlHandlerEx cbex, IntPtr context);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool CloseHandle(IntPtr hObject);
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        #endregion
        #region Constants
        public const int SERVICE_CONTROL_STOP = 1;
        public const int SERVICE_CONTROL_DEVICEEVENT = 11;
        public const int SERVICE_CONTROL_SHUTDOWN = 5;
        public const int SERVICE_CONTROL_SESSIONCHANGE = 0x0000000E;       
        // WTSWaitSystemEvent local server handle
        public const int WTS_CURRENT_SERVER_HANDLE = 0;
        public const int WTS_CURRENT_SESSION     =  0;
        [Flags]
        public enum WaitSystemEventFlags {
            /* ===================================================================== 
             == EVENT - Event flags for WTSWaitSystemEvent
             ===================================================================== */
            None = 0x00000000, // return no event
            CreatedWinstation = 0x00000001, // new WinStation created
            DeletedWinstation = 0x00000002, // existing WinStation deleted
            RenamedWinstation = 0x00000004, // existing WinStation renamed
            ConnectedWinstation = 0x00000008, // WinStation connect to client
            DisconnectedWinstation = 0x00000010, // WinStation logged on without client           
            LogonUser = 0x00000020, // user logged on to existing WinStation
            LogoffUser = 0x00000040, // user logged off from existing WinStation
            WinstationStateChange = 0x00000080, // WinStation state change
            LicenseChange = 0x00000100, // license state change
            AllEvents = 0x7fffffff, // wait for all event types
            // Unfortunately cannot express this as an unsigned long...
            //FlushEvent = 0x80000000 // unblock all waiters
        }
        public const UInt32 FlushEvent = 0x80000000;
        #endregion
        /************************************************************************************************/
        /*                                  Private members                                             */
        /************************************************************************************************/
        #region Private members
        private String m_ServerName = Environment.MachineName;
        private bool m_unregistered = false;
        private ServiceControlHandlerEx myCallback;
        private bool tsObserverRunning = false;
        private Thread tsObserverThread;
        IntPtr hServ;        
        #endregion
        
        /************************************************************************************************/
        /*                                  Constructors                                                */
        /************************************************************************************************/
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Oerlikon.Balzers.Rdp.Service.RdpSessionInfo">RdpSessionInfo</see> class. 
        /// </summary>
        /// <remarks></remarks>
        public RdpSessionInfo() : this(Environment.MachineName) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Oerlikon.Balzers.Rdp.Service.RdpSessionInfo"/> class.
        /// </summary>
        /// <param name="ServerName"></param>
        public RdpSessionInfo(String ServerName) : base() {
            this.m_ServerName = ServerName;
            this.hServ = WTSOpenServer(this.m_ServerName);
            tsObserverThread = new Thread(StartTerminalSessionObservation);
            tsObserverThread.Start(hServ);          
        }     
        ~RdpSessionInfo() {
        }
        #endregion Constructors
        /************************************************************************************************/
        /*                                  Methods                                                     */
        /************************************************************************************************/
        #region Public methods
        public void StartTerminalSessionObservation(object hServ) {                       
            string msg;
            IntPtr pEvents = IntPtr.Zero;
            IntPtr hServer = (IntPtr)hServ;
            List<TerminalSessionInfo> oldSessions, newSessions;
            TerminalSessionInfo tsi;
            WM_WTSSESSION_CHANGE_TYPE changeType;
            // initial read actual sessions
            oldSessions = ListSessions(false);
            newSessions = new List<TerminalSessionInfo>(oldSessions.ToArray());            
            tsObserverRunning = true;
            while(this.tsObserverRunning) {
                if(WTSWaitSystemEvent(hServer, (UInt32)WaitSystemEventFlags.AllEvents, out pEvents)) {
                    WaitSystemEventFlags eventType = GetSystemEventType(pEvents);
                    switch(eventType) {
                        case WaitSystemEventFlags.ConnectedWinstation:
                        case WaitSystemEventFlags.CreatedWinstation:
                        case WaitSystemEventFlags.LogonUser:                           
                            newSessions = ListSessions(false);
                            tsi = GetChangedTerminalSession(oldSessions, newSessions, out changeType);
                            oldSessions.Clear();
                            oldSessions.AddRange(newSessions.ToArray());
                            if(tsi != null && tsi.SessionInfo.iSessionID != 0)
                                OnSessionChanged(new TerminalSessionChangedEventArgs(changeType, tsi.SessionInfo.iSessionID, tsi));
                            break;
                        case WaitSystemEventFlags.DeletedWinstation:                      
                        case WaitSystemEventFlags.DisconnectedWinstation:
                        case WaitSystemEventFlags.LogoffUser:
                        case WaitSystemEventFlags.WinstationStateChange:                          
                            newSessions = ListSessions(false);
                            tsi = GetChangedTerminalSession(oldSessions, newSessions, out changeType);                           
                            oldSessions.Clear();
                            oldSessions.AddRange(newSessions.ToArray());
                            if(tsi != null && tsi.SessionInfo.iSessionID != 0)
                                OnSessionChanged(new TerminalSessionChangedEventArgs(changeType, tsi.SessionInfo.iSessionID, tsi));
                            break;                                                                                           
                        default:
                            break;
                    }
                }
                else {
                    uint winErrorCode = Win32Sec.GetLastError();
                    msg = new System.ComponentModel.Win32Exception((int)winErrorCode).Message;
                    WindowsEventLogHelper.WriteEventLog(msg, EventLogEntryType.Error);
                    WindowsEventLogHelper.WriteEventLog(RdpControl.SVC_NAME + " " + System.Reflection.MethodInfo.GetCurrentMethod().Name + " - methode failed: " + msg, EventLogEntryType.Error);
                }
               Thread.Sleep(100);
            }
            WTSCloseServer(hServer);
        }
        public void StopTerminalSessionObservation(object hServ) {
            this.tsObserverRunning = false;
            IntPtr pEvents = IntPtr.Zero;            
            // unlock the waiter
            WTSWaitSystemEvent((IntPtr)hServ, FlushEvent, out pEvents);
            tsObserverThread.Join(200);
        }
       
        public static IntPtr OpenServer(String Name) {
            IntPtr server = WTSOpenServer(Name);
            return server;
        }
        public static void CloseServer(IntPtr ServerHandle) {
            WTSCloseServer(ServerHandle);
        }
        /// <summary>
        /// Read all session info running on the system.
        /// </summary>
        /// <param name="RdpOnly">If set to <see langword="true"/>, then only Rdp sessions
        /// will be listed; otherwise, all session types <see cref="T:Oerlikon.Balzers.Rdp.Interfaces.WTS_CLIENT_PROTOCOL_TYPE"/> .</param>
        public List<TerminalSessionInfo> ListSessions(bool RdpOnly) {
            IntPtr server = IntPtr.Zero;
            List<TerminalSessionInfo> ret = new List<TerminalSessionInfo>();
            //server = OpenServer(this.m_ServerName);
            try {
                IntPtr ppSessionInfo = IntPtr.Zero;
                Int32 count = 0;
                Int32 retval = WTSEnumerateSessions(this.hServ, 0, 1, ref ppSessionInfo, ref count);
                Int32 dataSize = Marshal.SizeOf(typeof(WTS_SESSION_INFO));
                Int64 current = (int)ppSessionInfo;
                if(retval != 0) {
                    for(int i = 0; i < count; i++) {
                        TerminalSessionInfo tsi = GetSessionInfo(this.hServ, (System.IntPtr)current);                      
                        current += dataSize;
                        if(tsi.ProtocolType == WTS_CLIENT_PROTOCOL_TYPE.RDP || !RdpOnly)
                            ret.Add(tsi);
                    }
                    WTSFreeMemory(ppSessionInfo);
                }
            }
            finally {
                //CloseServer(server);
            }
            return ret;
        }
      
        #endregion Public methods
        #region Private methods
        private TerminalSessionInfo GetChangedTerminalSession(List<TerminalSessionInfo> oldSessions, List<TerminalSessionInfo> newSessions, out WM_WTSSESSION_CHANGE_TYPE sessionChangeType) {
            TerminalSessionInfo retval = new TerminalSessionInfo(0);
            sessionChangeType = (WM_WTSSESSION_CHANGE_TYPE)0;
            // session added
            if(newSessions.Count > oldSessions.Count) {
                retval = newSessions.Where(s => oldSessions.Where(old => old.SessionInfo.iSessionID == s.SessionInfo.iSessionID).ToList().Count == 0).FirstOrDefault();
                if(retval.SessionInfo.oState == WTS_CONNECTSTATE_CLASS.WTSConnected
                    || retval.SessionInfo.oState == WTS_CONNECTSTATE_CLASS.WTSActive
                    || retval.SessionInfo.oState == WTS_CONNECTSTATE_CLASS.WTSConnectQuery)
                    sessionChangeType = (retval.ProtocolType == WTS_CLIENT_PROTOCOL_TYPE.RDP) ? WM_WTSSESSION_CHANGE_TYPE.WTS_REMOTE_CONNECT : WM_WTSSESSION_CHANGE_TYPE.WTS_CONSOLE_CONNECT;
            }
            else if(newSessions.Count < oldSessions.Count) {
                retval = oldSessions.Where(s => newSessions.Where(old => old.SessionInfo.iSessionID == s.SessionInfo.iSessionID).ToList().Count == 0).FirstOrDefault();
                retval.SessionInfo.oState = WTS_CONNECTSTATE_CLASS.WTSDisconnected;
                retval.WtsInfo.State = WTS_CONNECTSTATE_CLASS.WTSDisconnected;  
                sessionChangeType = (retval.ProtocolType == WTS_CLIENT_PROTOCOL_TYPE.RDP) ? WM_WTSSESSION_CHANGE_TYPE.WTS_REMOTE_DISCONNECT : WM_WTSSESSION_CHANGE_TYPE.WTS_CONSOLE_DISCONNECT;
            }
            else {
                retval = newSessions.Where(s => oldSessions.Where(old => old.SessionInfo.iSessionID == s.SessionInfo.iSessionID && old.SessionInfo.oState != s.SessionInfo.oState).ToList().Count > 0 && s.SessionInfo.iSessionID != 0).FirstOrDefault();
                if(retval.SessionInfo.oState == WTS_CONNECTSTATE_CLASS.WTSConnected
                   || retval.SessionInfo.oState == WTS_CONNECTSTATE_CLASS.WTSActive
                   || retval.SessionInfo.oState == WTS_CONNECTSTATE_CLASS.WTSConnectQuery)
                    sessionChangeType = (retval.ProtocolType == WTS_CLIENT_PROTOCOL_TYPE.RDP) ? WM_WTSSESSION_CHANGE_TYPE.WTS_REMOTE_CONNECT : WM_WTSSESSION_CHANGE_TYPE.WTS_CONSOLE_CONNECT;
                else if(retval.SessionInfo.oState == WTS_CONNECTSTATE_CLASS.WTSDisconnected
                    || retval.SessionInfo.oState == WTS_CONNECTSTATE_CLASS.WTSDown
                    || retval.SessionInfo.oState == WTS_CONNECTSTATE_CLASS.WTSIdle
                    || retval.SessionInfo.oState == WTS_CONNECTSTATE_CLASS.WTSListen
                    || retval.SessionInfo.oState == WTS_CONNECTSTATE_CLASS.WTSReset
                    || retval.SessionInfo.oState == WTS_CONNECTSTATE_CLASS.WTSShadow)
                    sessionChangeType = (retval.ProtocolType == WTS_CLIENT_PROTOCOL_TYPE.RDP) ? WM_WTSSESSION_CHANGE_TYPE.WTS_REMOTE_DISCONNECT : WM_WTSSESSION_CHANGE_TYPE.WTS_CONSOLE_DISCONNECT;
            }
            return retval;
        }
        private WaitSystemEventFlags GetSystemEventType(IntPtr pEvents) {
            if(((int)pEvents & (int)WaitSystemEventFlags.ConnectedWinstation) == (int)WaitSystemEventFlags.ConnectedWinstation)
                return WaitSystemEventFlags.ConnectedWinstation;
            else if(((int)pEvents & (int)WaitSystemEventFlags.CreatedWinstation) == (int)WaitSystemEventFlags.CreatedWinstation)
                return WaitSystemEventFlags.CreatedWinstation;         
            else if(((int)pEvents & (int)WaitSystemEventFlags.DisconnectedWinstation) == (int)WaitSystemEventFlags.DisconnectedWinstation)
                return WaitSystemEventFlags.DisconnectedWinstation;
            else if(((int)pEvents & (int)WaitSystemEventFlags.LicenseChange) == (int)WaitSystemEventFlags.LicenseChange)
                return WaitSystemEventFlags.LicenseChange;
            else if(((int)pEvents & (int)WaitSystemEventFlags.LogoffUser) == (int)WaitSystemEventFlags.LogoffUser)
                return WaitSystemEventFlags.LogoffUser;
            else if(((int)pEvents & (int)WaitSystemEventFlags.LogonUser) == (int)WaitSystemEventFlags.LogonUser)
                return WaitSystemEventFlags.LogonUser;
            else if(((int)pEvents & (int)WaitSystemEventFlags.RenamedWinstation) == (int)WaitSystemEventFlags.RenamedWinstation)
                return WaitSystemEventFlags.RenamedWinstation;
            else if(((int)pEvents & (int)WaitSystemEventFlags.WinstationStateChange) == (int)WaitSystemEventFlags.WinstationStateChange)
                return WaitSystemEventFlags.WinstationStateChange;
            else return WaitSystemEventFlags.None;
       
        }     
        /// <param name="pServer"></param>
        /// <param name="pSessionInfo"></param>
        private TerminalSessionInfo GetSessionInfo(IntPtr pServer, IntPtr pSessionInfo) {
            int iCurrent = (int)pSessionInfo;
            uint iReturned = 0;
            WTS_CLIENT_ADDRESS oClientAddres = new WTS_CLIENT_ADDRESS();
            WTS_CLIENT_DISPLAY oClientDisplay = new WTS_CLIENT_DISPLAY();
            WTS_CLIENT_PROTOCOL_TYPE oClientProtocol = WTS_CLIENT_PROTOCOL_TYPE.UNKNOWN;
            WTS_CLIENT_INFO oClientInfo = new WTS_CLIENT_INFO();
            WTSINFO oWtsInfo = new WTSINFO();
            string sIPAddress = string.Empty;
            string sUserName = string.Empty, sClientName = string.Empty;
            string sDomain = string.Empty;
            string sClientApplicationDirectory = string.Empty;
            TerminalSessionInfo retval = new TerminalSessionInfo(0);
            // Get session info structure
            WTS_SESSION_INFO oSessionInfo = (WTS_SESSION_INFO)Marshal.PtrToStructure((System.IntPtr)iCurrent, typeof(WTS_SESSION_INFO));
            //Get the IP address of the Terminal Services User
            IntPtr pAddress = IntPtr.Zero;
            if(WTSQuerySessionInformation(pServer, oSessionInfo.iSessionID, WTS_INFO_CLASS.WTSClientAddress, out pAddress, out iReturned) == true) {
                oClientAddres = (WTS_CLIENT_ADDRESS)Marshal.PtrToStructure(pAddress, oClientAddres.GetType());
                sIPAddress = oClientAddres.bAddress[2] + "." + oClientAddres.bAddress[3] + "." + oClientAddres.bAddress[4] + "." + oClientAddres.bAddress[5];
            }
            //Get the User Name of the Terminal Services User
            if(WTSQuerySessionInformation(pServer, oSessionInfo.iSessionID, WTS_INFO_CLASS.WTSUserName, out pAddress, out iReturned) == true) {
                sUserName = Marshal.PtrToStringAnsi(pAddress);
            }
            //Get the Client Name of the Terminal Services User
            if(WTSQuerySessionInformation(pServer, oSessionInfo.iSessionID, WTS_INFO_CLASS.WTSClientName, out pAddress, out iReturned) == true) {
                sClientName = Marshal.PtrToStringAnsi(pAddress);
            }
            //Get the Domain Name of the Terminal Services User
            if(WTSQuerySessionInformation(pServer, oSessionInfo.iSessionID, WTS_INFO_CLASS.WTSDomainName, out pAddress, out iReturned) == true) {
                sDomain = Marshal.PtrToStringAnsi(pAddress);
            }
            //Get the Display Information  of the Terminal Services User
            if(WTSQuerySessionInformation(pServer, oSessionInfo.iSessionID, WTS_INFO_CLASS.WTSClientDisplay, out pAddress, out iReturned) == true) {
                oClientDisplay = (WTS_CLIENT_DISPLAY)Marshal.PtrToStructure(pAddress, oClientDisplay.GetType());
            }
            //Get the Application Directory of the Terminal Services User
            if(WTSQuerySessionInformation(pServer, oSessionInfo.iSessionID, WTS_INFO_CLASS.WTSClientDirectory, out pAddress, out iReturned) == true) {
                sClientApplicationDirectory = Marshal.PtrToStringAnsi(pAddress);
            }
            //Get protocol type
            if(WTSQuerySessionInformation(pServer, oSessionInfo.iSessionID, WTS_INFO_CLASS.WTSClientProtocolType, out pAddress, out iReturned) == true) {
                oClientProtocol = (WTS_CLIENT_PROTOCOL_TYPE)Marshal.ReadInt16(pAddress);               
            }
            //Get client info
            if(WTSQuerySessionInformation(pServer, oSessionInfo.iSessionID, WTS_INFO_CLASS.WTSClientInfo, out pAddress, out iReturned) == true) {
                oClientInfo = (WTS_CLIENT_INFO)Marshal.PtrToStructure(pAddress, oClientInfo.GetType());
                //sUserName = String.IsNullOrEmpty(sUserName) ? oClientInfo.UserName : sUserName;             
            }
            //Get WTS info
            if(WTSQuerySessionInformation(pServer, oSessionInfo.iSessionID, WTS_INFO_CLASS.WTSSessionInfo, out pAddress, out iReturned) == true) {
                oWtsInfo = (WTSINFO)Marshal.PtrToStructure(pAddress, oWtsInfo.GetType());
            }
            // fill result
            retval.SessionInfo = oSessionInfo;
            //retval.SessionInfo.oState = oSessionInfo.oState;
            //retval.SessionInfo.sWinsWorkstationName = oSessionInfo.sWinsWorkstationName == null ? "" : oSessionInfo.sWinsWorkstationName;
            retval.UserName = sUserName == null ? "" : sUserName;
            retval.ClientMachineName = sClientName == null ? "" : sClientName;
            retval.ClientIPAddress = sIPAddress == null ? "" : sIPAddress;
            retval.Domain = sDomain == null ? "" : sDomain;
            retval.ProtocolType = oClientProtocol;
            retval.ClientInfo = oClientInfo;
            retval.WtsInfo = oWtsInfo;                   
            return retval;
        }
        #endregion Private methods
        #region Handlers   
        private event TerminalSessionChangedEventHandler mSessionChangedEventHandler;
        /// <summary>
        /// Occurs when a terminal session has changed.
        /// </summary>
        /// <remarks>
        /// Following change types will be observed: <see cref="T:Oerlikon.Balzers.Rdp.Interfaces.WM_WTSSESSION_CHANGE"/> and <see cref="F:Oerlikon.Balzers.Rdp.Interfaces.WM_WTSSESSION_CHANGE.WM_WTSSESSION_CHANGE"/>
        /// </remarks>
        /// <seealso href="http://pinvoke.net/default.aspx/wtsapi32/WTSRegisterSessionNotification.html">WTSRegisterSessionNotification</seealso>
        public event TerminalSessionChangedEventHandler SessionChanged {
            add {
                if(mSessionChangedEventHandler == null || !mSessionChangedEventHandler.GetInvocationList().Contains(value))
                    mSessionChangedEventHandler += value;
            }
            remove {
                mSessionChangedEventHandler -= value;
            }
        }
        public void OnSessionChanged(TerminalSessionChangedEventArgs SessionChangedEventArg) {
            if(mSessionChangedEventHandler != null) {
                TerminalSessionChangedSaveInvoker.SafeInvokeEvent(mSessionChangedEventHandler, SessionChangedEventArg);
            }
        }
        #endregion Handlers
        #region IDisposable Members
        public void Dispose() {
            if(!m_unregistered) {
                StopTerminalSessionObservation(this.hServ);                
                m_unregistered = true;
            }
        }
        #endregion
    }
    }
