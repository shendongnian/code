    public static class LocalSystemConnection
    {
        [DllImport("wininet.dll", SetLastError=true)]
        extern static bool InternetGetConnectedState(out ConnectionStates lpdwFlags, long dwReserved);
        /// <summary>
        /// Retrieves the connected state of the local system.
        /// </summary>
        /// <param name="connectionStates">A <see cref="ConnectionStates"/> value that receives the connection description.</param>
        /// <returns>
        /// A return value of true indicates that either the modem connection is active, or a LAN connection is active and a proxy is properly configured for the LAN.
        /// A return value of false indicates that neither the modem nor the LAN is connected.
        /// If false is returned, the <see cref="ConnectionStates.Configured"/> flag may be set to indicate that autodial is configured to "always dial" but is not currently active.
        /// If autodial is not configured, the function returns false.
        /// </returns>
        public static bool IsConnectedToInternet(out ConnectionStates connectionStates)
        {
            connectionStates = ConnectionStates.Unknown;
            return InternetGetConnectedState(out connectionStates, 0);
        }
        /// <summary>
        /// Retrieves the connected state of the local system.
        /// </summary>
        /// <returns>
        /// A return value of true indicates that either the modem connection is active, or a LAN connection is active and a proxy is properly configured for the LAN.
        /// A return value of false indicates that neither the modem nor the LAN is connected.
        /// If false is returned, the <see cref="ConnectionStates.Configured"/> flag may be set to indicate that autodial is configured to "always dial" but is not currently active.
        /// If autodial is not configured, the function returns false.
        /// </returns>
        public static bool IsConnectedToInternet()
        {
            ConnectionStates state = ConnectionStates.Unknown;
            return IsConnectedToInternet(out state);
        }
    }
    [Flags]
    public enum ConnectionStates
    {
        /// <summary>
        /// Unknown state.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Local system uses a modem to connect to the Internet.
        /// </summary>
        Modem = 0x1,
        /// <summary>
        /// Local system uses a local area network to connect to the Internet.
        /// </summary>
        LAN = 0x2,
        /// <summary>
        /// Local system uses a proxy server to connect to the Internet.
        /// </summary>
        Proxy = 0x4,
        /// <summary>
        /// Local system has RAS (Remote Access Services) installed.
        /// </summary>
        RasInstalled = 0x10,
        /// <summary>
        /// Local system is in offline mode.
        /// </summary>
        Offline = 0x20,
        /// <summary>
        /// Local system has a valid connection to the Internet, but it might or might not be currently connected.
        /// </summary>
        Configured = 0x40,
    }
