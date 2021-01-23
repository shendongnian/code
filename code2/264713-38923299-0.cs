    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Linq;
    using System.Windows.Forms;
    using System.Reflection;
    
    namespace Rdp.Interfaces {
    
       #region struct members
        //Structure for Terminal Service Client IP Address
        /// </remarks>
        [StructLayout(LayoutKind.Sequential)]
        public struct WTS_CLIENT_ADDRESS {
            /// <summary>
            ///  Address family. This member can
            /// be <b>AF_INET</b>, <b>AF_INET6</b>, <b>AF_IPX</b>, <b>AF_NETBIOS</b>,
            /// or <b>AF_UNSPEC</b>.
            /// </summary>
            public int iAddressFamily;
            /// <summary>
            /// Client network address. The format of the field of <b>Address</b> depends on the
            /// address type as specified by the <b>AddressFamily</b> member.
            /// <para>For an address family <b>AF_INET</b>: <b>Address </b>contains the IPV4
            /// address of the client as a null-terminated string.</para>
            /// 	<para>For an family <b>AF_INET6</b>: <b>Address </b>contains the IPV6 address of
            /// the client as raw byte values. (For example, the address "FFFF::1"
            /// would be represented as the following series of byte values: "0xFF 0xFF
            /// 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00
            /// 0x01")</para>
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            public byte[] bAddress;
        }
    
        /// <summary>
        /// Maximum string lengths constants used within RDP API structures <see href="https://msdn.microsoft.com/en-us/library/bb736369(v=vs.85).aspx#">MSDN</see>
        /// </summary>
        /// <seealso href="https://msdn.microsoft.com/en-us/library/bb736369(v=vs.85).aspx">MSDN
        /// Example</seealso>
        public struct WTSAPI32_CONSTANTS {
            /// <summary>
            /// Maximum string lengths constants used within RDP API structures
            /// </summary>
            /// <seealso cref="T:Oerlikon.Balzers.Rdp.Interfaces.WTS_CLIENT_INFO">Example
            /// WTS_CLIENT_INFO</seealso>
            public const int USERNAME_LENGTH = 20;
            /// <summary>
            /// Maximum string lengths constants used within RDP API structures
            /// </summary>
            /// <seealso cref="T:Oerlikon.Balzers.Rdp.Interfaces.WTS_CLIENT_INFO">Example
            /// WTS_CLIENT_INFO</seealso>
            public const int CLIENTNAME_LENGTH = 20;
            /// <summary>
            /// Maximum string lengths constants used within RDP API structures
            /// </summary>
            /// <seealso cref="T:Oerlikon.Balzers.Rdp.Interfaces.WTS_CLIENT_INFO">Example
            /// WTS_CLIENT_INFO</seealso>
            public const int CLIENTADDRESS_LENGTH = 30;
            /// <summary>
            /// Maximum string lengths constants used within RDP API structures
            /// </summary>
            /// <seealso cref="T:Oerlikon.Balzers.Rdp.Interfaces.WTS_CLIENT_INFO">Example
            /// WTS_CLIENT_INFO</seealso>
            public const int MAX_ELAPSED_TIME_LENGTH = 15;
            /// <summary>
            /// Maximum string lengths constants used within RDP API structures
            /// </summary>
            /// <seealso cref="T:Oerlikon.Balzers.Rdp.Interfaces.WTS_CLIENT_INFO">Example
            /// WTS_CLIENT_INFO</seealso>
            public const int MAX_DATE_TIME_LENGTH = 15;
            /// <summary>
            /// Maximum string lengths constants used within RDP API structures
            /// </summary>
            /// <seealso cref="T:Oerlikon.Balzers.Rdp.Interfaces.WTS_CLIENT_INFO">Example
            /// WTS_CLIENT_INFO</seealso>
            public const int WINSTATIONNAME_LENGTH = 32;
            /// <summary>
            /// Maximum string lengths constants used within RDP API structures
            /// </summary>
            /// <seealso cref="T:Oerlikon.Balzers.Rdp.Interfaces.WTS_CLIENT_INFO">Example
            /// WTS_CLIENT_INFO</seealso>
            public const int DOMAIN_LENGTH = 17;
            /// <summary>
            /// Maximum string lengths constants used within RDP API structures
            /// </summary>
            /// <seealso cref="T:Oerlikon.Balzers.Rdp.Interfaces.WTS_CLIENT_INFO">Example
            /// WTS_CLIENT_INFO</seealso>
            public const int WTS_DRIVE_LENGTH = 3;
            /// <summary>
            /// Maximum string lengths constants used within RDP API structures
            /// </summary>
            /// <seealso cref="T:Oerlikon.Balzers.Rdp.Interfaces.WTS_CLIENT_INFO">Example
            /// WTS_CLIENT_INFO</seealso>
            public const int WTS_LISTENER_NAME_LENGTH = 32;
            /// <summary>
            /// Maximum string lengths constants used within RDP API structures
            /// </summary>
            /// <seealso cref="T:Oerlikon.Balzers.Rdp.Interfaces.WTS_CLIENT_INFO">Example
            /// WTS_CLIENT_INFO</seealso>
            public const int WTS_COMMENT_LENGTH = 60;
            /// <summary>
            /// Maximum string lengths constants used within RDP API structures
            /// </summary>
            /// <seealso cref="T:Oerlikon.Balzers.Rdp.Interfaces.WTS_CLIENT_INFO">Example
            /// WTS_CLIENT_INFO</seealso>
            public const int PRODUCTINFO_COMPANYNAME_LENGTH = 256;
            /// <summary>
            /// Maximum string lengths constants used within RDP API structures
            /// </summary>
            /// <seealso cref="T:Oerlikon.Balzers.Rdp.Interfaces.WTS_CLIENT_INFO">Example
            /// WTS_CLIENT_INFO</seealso>
            public const int PRODUCTINFO_PRODUCTID_LENGTH = 4;
            /// <summary>
            /// Maximum string lengths constants used within RDP API structures
            /// </summary>
            /// <seealso cref="T:Oerlikon.Balzers.Rdp.Interfaces.WTS_CLIENT_INFO">Example
            /// WTS_CLIENT_INFO</seealso>
            public const int VALIDATIONINFORMATION_LICENSE_LENGTH = 16384;
            /// <summary>
            /// Maximum string lengths constants used within RDP API structures
            /// </summary>
            /// <seealso cref="T:Oerlikon.Balzers.Rdp.Interfaces.WTS_CLIENT_INFO">Example
            /// WTS_CLIENT_INFO</seealso>
            public const int VALIDATIONINFORMATION_HARDWAREID_LENGTH = 20;
            /// <summary>
            /// Maximum string lengths constants used within RDP API structures
            /// </summary>
            /// <seealso cref="T:Oerlikon.Balzers.Rdp.Interfaces.WTS_CLIENT_INFO">Example
            /// WTS_CLIENT_INFO</seealso>
            public const int MAX_PATH = 260;
    
        }
    
        //Structure for Terminal Service Client Infostructure
        /// <summary>
        /// Contains information about a Remote Desktop Connection (RDC) client.
        /// </summary>
        /// <seealso href="https://msdn.microsoft.com/en-us/library/bb736369(v=vs.85).aspx#">MSDN</seealso>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        [Serializable]
        public struct WTS_CLIENT_INFO {
            /// <summary>
            ///  The NetBIOS name of the client computer.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = WTSAPI32_CONSTANTS.CLIENTNAME_LENGTH + 1)]
            public string ClientMachineName;
            /// <summary>
            ///  The domain name of the client computer.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = WTSAPI32_CONSTANTS.DOMAIN_LENGTH + 1)]
            public string Domain;
            /// <summary>
            ///  The client user name.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = WTSAPI32_CONSTANTS.USERNAME_LENGTH + 1)]
            public string UserName;
            /// <summary>
            ///  The folder for the initial program.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = WTSAPI32_CONSTANTS.MAX_PATH + 1)]
            public string WorkDirectory;
            /// <summary>
            ///  The program to start on connection.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = WTSAPI32_CONSTANTS.MAX_PATH + 1)]
            public string InitialProgram;
            /// <summary>
            ///  The security level of encryption.
            /// </summary>
            [MarshalAs(UnmanagedType.U1)]
            public byte EncryptionLevel;
            /// <summary>
            ///  The address family. This member can
            /// be <b>AF_INET</b>, <b>AF_INET6</b>, <b>AF_IPX</b>, <b>AF_NETBIOS</b>,
            /// or <b>AF_UNSPEC</b>.
            /// </summary>
            [MarshalAs(UnmanagedType.U4)]
            public UInt32 ClientAddressFamily;
            /// <summary>
            ///  The client network address.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = WTSAPI32_CONSTANTS.CLIENTADDRESS_LENGTH + 1)]
            public UInt16[] ClientAddress;
            /// <summary>
            ///  Horizontal dimension, in pixels, of the client's display.
            /// </summary>
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 HRes;
            /// <summary>
            ///  Vertical dimension, in pixels, of the client's display.
            /// </summary>
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 VRes;
            /// <summary>
            ///  Color depth of the client's display. For possible values, see
            /// the <b>ColorDepth</b> member of the <b>WTS_CLIENT_DISPLAY</b> structure.
            /// </summary>
            /// <seealso cref="T:Oerlikon.Balzers.Rdp.Interfaces.WTS_CLIENT_DISPLAY"/>
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 ColorDepth;
            /// <summary>
            ///  The location of the client ActiveX control DLL.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = WTSAPI32_CONSTANTS.MAX_PATH + 1)]
            public string ClientDirectory;
            /// <summary>
            ///  The client build number.
            /// </summary>
            [MarshalAs(UnmanagedType.U4)]
            public UInt32 ClientBuildNumber;
            /// <summary>
            ///  Reserved.
            /// </summary>
            [MarshalAs(UnmanagedType.U4)]
            public UInt32 ClientHardwareId;
            /// <summary>
            ///  Reserved.
            /// </summary>
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 ClientProductId;
            /// <summary>
            ///  The number of output buffers on the server per session.
            /// </summary>
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 OutBufCountHost;
            /// <summary>
            ///  The number of output buffers on the client.
            /// </summary>
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 OutBufCountClient;
            /// <summary>
            ///  The length of the output buffers, in bytes.
            /// </summary>
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 OutBufLength;
            /// <summary>
            ///  The device ID of the network adapter.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = WTSAPI32_CONSTANTS.MAX_PATH + 1)]
            public string DeviceId;
        }
    
        /// <summary>
        /// Contains information about a Remote Desktop Services session.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        [Serializable]
        public struct WTSINFO {
            /// <summary>
            /// A value of the <b>WTS_CONNECTSTATE_CLASS</b> enumeration type that indicates the
            /// session's current connection state.
            /// </summary>
            public WTS_CONNECTSTATE_CLASS State;
            public UInt32 SessionId;
            public UInt32 IncomingBytes;
            public UInt32 OutgoingBytes;
            public UInt32 IncomingFrames;
            public UInt32 OutgoingFrames;
            public UInt32 IncomingCompressedBytes;
            public UInt32 OutgoingCompressedBytes;
    
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = WTSAPI32_CONSTANTS.WINSTATIONNAME_LENGTH)]
            public String WinStationName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = WTSAPI32_CONSTANTS.DOMAIN_LENGTH)]
            public String Domain;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = WTSAPI32_CONSTANTS.USERNAME_LENGTH + 1)]
            public String UserName;
    
            [MarshalAs(UnmanagedType.I8)]
            public Int64 ConnectTime;
            [MarshalAs(UnmanagedType.I8)]
            public Int64 DisconnectTime;
            [MarshalAs(UnmanagedType.I8)]
            public Int64 LastInputTime;
            [MarshalAs(UnmanagedType.I8)]
            public Int64 LogonTime;
            [MarshalAs(UnmanagedType.I8)]
            public Int64 CurrentTime;
        }
    
        /// <summary>
        /// 	<para>Contains information about a client session on a Remote Desktop Session
        /// Host (RD Session Host) server.</para>
        /// </summary>
        /// <seealso href="http://pinvoke.net/default.aspx/Structures/_WTS_SESSION_INFO.html">http://pinvoke.net/</seealso>
        /// <seealso href="https://msdn.microsoft.com/en-us/library/aa383864(v=vs.85).aspx">MSDN</seealso>
        [StructLayout(LayoutKind.Sequential)]
        [Serializable]
        public struct WTS_SESSION_INFO {
            /// <summary>
            /// A Terminal Services session identifier. To indicate the session in which the
            /// calling application is running.<br/>
            /// </summary>
            public int iSessionID;
            /// <summary>
            /// Pointer to a null-terminated string that contains the WinStation name of this
            /// session. The WinStation name is a name that Windows associates with the session,
            /// for example, "services", "console", or
            /// "RDP-Tcp#0".
            /// </summary>
            [MarshalAs(UnmanagedType.LPStr)]
            public string sWinsWorkstationName;
            /// <summary>
            /// A value from the <b>WTS_CONNECTSTATE_CLASS</b> enumeration type that indicates
            /// the session's current connection state.
            /// </summary>
            /// <seealso href="https://msdn.microsoft.com/en-us/library/aa383860(v=vs.85).aspx">MSDN</seealso>
            /// <seealso cref="T:Oerlikon.Balzers.Rdp.Interfaces.WTS_CONNECTSTATE_CLASS"/>
            public WTS_CONNECTSTATE_CLASS oState;
        }
    
        // Structure for Terminal Service Session Client Display
        /// <summary>
        /// Contains information about the display of a Remote Desktop Connection (RDC)
        /// client.
        /// </summary>
        /// <seealso href="https://msdn.microsoft.com/en-us/library/aa383858(v=vs.85).aspx">MSDN</seealso>
        [StructLayout(LayoutKind.Sequential)]
        public struct WTS_CLIENT_DISPLAY {
            /// <summary>
            /// Horizontal dimension, in pixels, of the client's display.
            /// </summary>
            public int iHorizontalResolution;
            /// <summary>
            ///  Vertical dimension, in pixels, of the client's display.
            /// </summary>
            public int iVerticalResolution;
            //1 = The display uses 4 bits per pixel for a maximum of 16 colors.
            //2 = The display uses 8 bits per pixel for a maximum of 256 colors.
            //4 = The display uses 16 bits per pixel for a maximum of 2^16 colors.
            //8 = The display uses 3-byte RGB values for a maximum of 2^24 colors.
            //16 = The display uses 15 bits per pixel for a maximum of 2^15 colors.
            public int iColorDepth;
        }
        #endregion struct members
    
    
        /************************************************************************************************/
        /*                                  enum members                                                */
        /************************************************************************************************/
        #region enum members
        /// <summary>
        /// Specifies the connection state of a Remote Desktop Services session.
        /// </summary>
        /// <seealso href="https://msdn.microsoft.com/en-us/library/aa383860(v=vs.85).aspx">MSDN</seealso>
        public enum WTS_CONNECTSTATE_CLASS {
            /// <summary>
            ///  A user is logged on to the WinStation.
            /// </summary>
            WTSActive,
            /// <summary>
            ///  The WinStation is connected to the client.
            /// </summary>
            WTSConnected,
            /// <summary>
            ///  The WinStation is in the process of connecting to the client.
            /// </summary>
            WTSConnectQuery,
            /// <summary>
            ///  The WinStation is shadowing another WinStation.
            /// </summary>
            WTSShadow,
            /// <summary>
            ///  The WinStation is active but the client is disconnected.
            /// </summary>
            WTSDisconnected,
            /// <summary>
            ///  The WinStation is waiting for a client to connect.
            /// </summary>
            WTSIdle,
            /// <summary>
            ///  The WinStation is listening for a connection. A listener session waits for
            /// requests for new client connections. No user is logged on a listener session. A
            /// listener session cannot be reset, shadowed, or changed to a regular client
            /// session.
            /// </summary>
            WTSListen,
            /// <summary>
            ///  The WinStation is being reset.
            /// </summary>
            WTSReset,
            /// <summary>
            ///  The WinStation is down due to an error.
            /// </summary>
            WTSDown,
            /// <summary>
            /// The WinStation is initializing.
            /// </summary>
            WTSInit
        }
    
        /// <summary>
        /// 	<para>A <b>USHORT</b> value that specifies information about the protocol type
        /// for the session. This is one of the following values:</para>
        /// </summary>
        /// <seealso href="https://msdn.microsoft.com/en-us/library/aa383861(v=vs.85).aspx">MSDN</seealso>
        public enum WTS_CLIENT_PROTOCOL_TYPE : ushort {
            /// <summary>
            /// The console session.
            /// </summary>
            CONSOLE = 0,
            /// <summary>
            ///  This value is retained for legacy purposes.
            /// </summary>
            LEGACY,
            /// <summary>
            ///  The RDP protocol
            /// </summary>
            RDP,
            /// <summary>
            ///  Custom value for internal use
            /// </summary>
            UNKNOWN
        }
    
        /// <summary>
        /// Contains values that indicate the type of session information to retrieve in a call to the <see cref="WTSQuerySessionInformation"/> function.
        /// </summary>
        public enum WTS_INFO_CLASS {
            /// <summary>
            /// A null-terminated string that contains the name of the initial program that Remote Desktop Services runs when the user logs on.
            /// </summary>
            WTSInitialProgram,
    
            /// <summary>
            /// A null-terminated string that contains the published name of the application that the session is running.
            /// </summary>
            WTSApplicationName,
    
            /// <summary>
            /// A null-terminated string that contains the default directory used when launching the initial program.
            /// </summary>
            WTSWorkingDirectory,
    
            /// <summary>
            /// This value is not used.
            /// </summary>
            WTSOEMId,
    
            /// <summary>
            /// A <B>ULONG</B> value that contains the session identifier.
            /// </summary>
            WTSSessionId,
    
            /// <summary>
            /// A null-terminated string that contains the name of the user associated with the session.
            /// </summary>
            WTSUserName,
    
            /// <summary>
            /// A null-terminated string that contains the name of the Remote Desktop Services session. 
            /// </summary>
            /// <remarks>
            /// <B>Note</B>  Despite its name, specifying this type does not return the window station name. 
            /// Rather, it returns the name of the Remote Desktop Services session. 
            /// Each Remote Desktop Services session is associated with an interactive window station. 
            /// Because the only supported window station name for an interactive window station is "WinSta0", 
            /// each session is associated with its own "WinSta0" window station. For more information, see <see href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms687096(v=vs.85).aspx">Window Stations</see>.
            /// </remarks>
            WTSWinStationName,
    
            /// <summary>
            /// A null-terminated string that contains the name of the domain to which the logged-on user belongs.
            /// </summary>
            WTSDomainName,
    
            /// <summary>
            /// The session's current connection state. For more information, see <see cref="WTS_CONNECTSTATE_CLASS"/>.
            /// </summary>
            WTSConnectState,
    
            /// <summary>
            /// A <B>ULONG</B> value that contains the build number of the client.
            /// </summary>
            WTSClientBuildNumber,
    
            /// <summary>
            /// A null-terminated string that contains the name of the client.
            /// </summary>
            WTSClientName,
    
            /// <summary>
            /// A null-terminated string that contains the directory in which the client is installed.
            /// </summary>
            WTSClientDirectory,
    
            /// <summary>
            /// A <B>USHORT</B> client-specific product identifier.
            /// </summary>
            WTSClientProductId,
    
            /// <summary>
            /// A <b>ULONG</b> value that contains a client-specific hardware identifier. This
            /// option is reserved for future use. PInvoke function
            /// WTSQuerySessionInformation will always return a value of 0.
            /// </summary>
            WTSClientHardwareId,
    
            /// <summary>
            /// The network type and network address of the client. For more information, see <see cref="WTS_CLIENT_ADDRESS"/>.
            /// </summary>
            /// <remarks>The IP address is offset by two bytes from the start of the <B>Address</B> member of the <see cref="WTS_CLIENT_ADDRESS"/> structure.</remarks>
            WTSClientAddress,
    
            /// <summary>
            /// Information about the display resolution of the client. For more information, see <see cref="WTS_CLIENT_DISPLAY"/>.
            /// </summary>
            WTSClientDisplay,
    
            /// <summary>
            /// A USHORT value that specifies information about the protocol type for the session. This is one of the following values:<BR/>
            /// 0 - The console session.<BR/>
            /// 1 - This value is retained for legacy purposes.<BR/>
            /// 2 - The RDP protocol.<BR/>
            /// </summary>
            WTSClientProtocolType,
    
            /// <summary>
            /// 	<para>This value returns <b>FALSE</b>. If you call PInvoke function
            /// GetLastError to get extended error information, <b>GetLastError</b> returns
            /// <b>ERROR_NOT_SUPPORTED</b>.</para>
            /// </summary>
            /// <remarks>
            /// 	<b>Windows Server 2008, Windows Vista, Windows Server 2003, and Windows XP:</b>
            /// This value is not used.
            /// </remarks>
            WTSIdleTime,
    
            /// <summary>
            /// This value returns <B>FALSE</B>. If you call the pinvoke GetLastError() to get extended error information, <B>GetLastError</B> returns <B>ERROR_NOT_SUPPORTED</B>.
            /// </summary>
            /// <remarks>
            /// <B>Windows Server 2008, Windows Vista, Windows Server 2003, and Windows XP:</B>  This value is not used.
            /// </remarks>
            WTSLogonTime,
    
            /// <summary>
            /// This value returns <B>FALSE</B>. If you call the pinvoke GetLastError() to get extended error information, <B>GetLastError</B> returns <B>ERROR_NOT_SUPPORTED</B>.
            /// </summary>
            /// <remarks>
            /// <B>Windows Server 2008, Windows Vista, Windows Server 2003, and Windows XP:</B>  This value is not used.
            /// </remarks>
            WTSIncomingBytes,
    
            /// <summary>
            /// This value returns <B>FALSE</B>. If you call the pinvoke GetLastError() to get extended error information, <B>GetLastError</B> returns <B>ERROR_NOT_SUPPORTED</B>.
            /// </summary>
            /// <remarks>
            /// <B>Windows Server 2008, Windows Vista, Windows Server 2003, and Windows XP:</B>  This value is not used.
            /// </remarks>
            WTSOutgoingBytes,
    
            /// <summary>
            /// This value returns <B>FALSE</B>. If you call the pinvoke GetLastError() to get extended error information, <B>GetLastError</B> returns <B>ERROR_NOT_SUPPORTED</B>.
            /// </summary>
            /// <remarks>
            /// <B>Windows Server 2008, Windows Vista, Windows Server 2003, and Windows XP:</B>  This value is not used.
            /// </remarks>
            WTSIncomingFrames,
    
            /// <summary>
            /// This value returns <B>FALSE</B>. If you call the pinvoke GetLastError() to get extended error information, <B>GetLastError</B> returns <B>ERROR_NOT_SUPPORTED</B>.
            /// </summary>
            /// <remarks>
            /// <B>Windows Server 2008, Windows Vista, Windows Server 2003, and Windows XP:</B>  This value is not used.
            /// </remarks>
            WTSOutgoingFrames,
    
            /// <summary>
            /// Information about a Remote Desktop Connection (RDC) client. For more
            /// information, see <see cref="T:Oerlikon.Balzers.Rdp.Interfaces.WTS_CLIENT_INFO"/>.
            /// </summary>
            /// <remarks>
            /// 	<b>Windows Vista, Windows Server 2003, and Windows XP:</b> This value is not
            /// supported. This value is supported beginning with Windows Server 2008 and
            /// Windows Vista with SP1.
            /// </remarks>
            WTSClientInfo,
    
            /// <summary>
            /// Information about a client session on an RD Session Host server. For more
            /// information, see <see cref="T:Oerlikon.Balzers.Rdp.Interfaces.WTS_SESSION_INFO"/>.
            /// </summary>
            /// <remarks>
            /// 	<b>Windows Vista, Windows Server 2003, and Windows XP:</b> This value is not
            /// supported. This value is supported beginning with Windows Server 2008 and
            /// Windows Vista with SP1.
            /// </remarks>
            WTSSessionInfo
        }
    
        #endregion
    
    }
