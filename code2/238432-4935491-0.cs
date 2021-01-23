    internal class Desktop
    {
        private IntPtr m_hCurWinsta = IntPtr.Zero;
        private IntPtr m_hCurDesktop = IntPtr.Zero;
        private IntPtr m_hWinsta = IntPtr.Zero;
        private IntPtr m_hDesk = IntPtr.Zero;
        /// <summary>
        /// associate the current thread to the default desktop
        /// </summary>
        /// <returns></returns>
        internal bool BeginInteraction()
        {
            EndInteraction();
            m_hCurWinsta = User32DLL.GetProcessWindowStation();
            if (m_hCurWinsta == IntPtr.Zero)
                return false;
            m_hCurDesktop = User32DLL.GetDesktopWindow();
            if (m_hCurDesktop == IntPtr.Zero)
                return false;
            m_hWinsta = User32DLL.OpenWindowStation("winsta0", false,
                WindowStationAccessRight.WINSTA_ACCESSCLIPBOARD |
                WindowStationAccessRight.WINSTA_ACCESSGLOBALATOMS |
                WindowStationAccessRight.WINSTA_CREATEDESKTOP |
                WindowStationAccessRight.WINSTA_ENUMDESKTOPS |
                WindowStationAccessRight.WINSTA_ENUMERATE |
                WindowStationAccessRight.WINSTA_EXITWINDOWS |
                WindowStationAccessRight.WINSTA_READATTRIBUTES |
                WindowStationAccessRight.WINSTA_READSCREEN |
                WindowStationAccessRight.WINSTA_WRITEATTRIBUTES
                );
            if (m_hWinsta == IntPtr.Zero)
                return false;
            User32DLL.SetProcessWindowStation(m_hWinsta);
            m_hDesk = User32DLL.OpenDesktop("default", OpenDesktopFlag.DF_NONE, false,
                    DesktopAccessRight.DESKTOP_CREATEMENU |
                    DesktopAccessRight.DESKTOP_CREATEWINDOW |
                    DesktopAccessRight.DESKTOP_ENUMERATE |
                    DesktopAccessRight.DESKTOP_HOOKCONTROL |
                    DesktopAccessRight.DESKTOP_JOURNALPLAYBACK |
                    DesktopAccessRight.DESKTOP_JOURNALRECORD |
                    DesktopAccessRight.DESKTOP_READOBJECTS |
                    DesktopAccessRight.DESKTOP_SWITCHDESKTOP |
                    DesktopAccessRight.DESKTOP_WRITEOBJECTS
                    );
            if (m_hDesk == IntPtr.Zero)
                return false;
            User32DLL.SetThreadDesktop(m_hDesk);
            return true;
        }
        /// <summary>
        /// restore
        /// </summary>
        internal void EndInteraction()
        {
            if (m_hCurWinsta != IntPtr.Zero)
                User32DLL.SetProcessWindowStation(m_hCurWinsta);
            if (m_hCurDesktop != IntPtr.Zero)
                User32DLL.SetThreadDesktop(m_hCurDesktop);
            if (m_hWinsta != IntPtr.Zero)
                User32DLL.CloseWindowStation(m_hWinsta);
            if (m_hDesk != IntPtr.Zero)
                User32DLL.CloseDesktop(m_hDesk);
        }
    }
    public static class User32DLL
    {
        /// <summary>
        /// The GetDesktopWindow function returns a handle to the desktop window. 
        /// The desktop window covers the entire screen. 
        /// The desktop window is the area on top of which other windows are painted. 
        /// </summary>
        /// <returns>The return value is a handle to the desktop window. </returns>
        [DllImport("User32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr GetDesktopWindow();
        /// <summary>
        /// Retrieves a handle to the current window station for the calling process.
        /// </summary>
        /// <returns>If the function succeeds,
        /// the return value is a handle to the window station.
        /// If the function fails, the return value is NULL.</returns>
        [DllImport("User32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr GetProcessWindowStation();
        /// <summary>
        /// Retrieves a handle to the desktop assigned to the specified thread.
        /// </summary>
        /// <param name="dwThread">[in] Handle to the thread
        ///     for which to return the desktop handle.</param>
        /// <returns>If the function succeeds, the return value is a handle to the 
        /// desktop associated with the specified thread. 
        /// If the function fails, the return value is NULL.</returns>
        [DllImport("User32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr GetThreadDesktop(uint dwThread);
        /// <summary>
        /// Opens the specified window station.
        /// </summary>
        /// <param name="lpszWinSta">Pointer to a null-terminated
        ///           string specifying the name of the window station 
        /// to be opened. Window station names are case-insensitive.
        /// This window station must belong to the current session.
        /// </param>
        /// <param name="fInherit">[in] If this value
        ///            is TRUE, processes created by this process 
        /// will inherit the handle. Otherwise, 
        /// the processes do not inherit this handle. 
        /// </param>
        /// <param name="dwDesiredAccess">[in] Access to the window station</param>
        /// <returns>If the function succeeds, the return value
        ///          is the handle to the specified window station.
        /// If the function fails, the return value is NULL.</returns>
        [DllImport("User32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr OpenWindowStation(string lpszWinSta
            , bool fInherit
            , WindowStationAccessRight dwDesiredAccess
            );
        /// <summary>
        /// Assigns the specified window station to the calling process. 
        /// This enables the process to access objects in the window
        /// station such as desktops, the clipboard, and global atoms. 
        /// All subsequent operations on the window station
        /// use the access rights granted to hWinSta.
        /// </summary>
        /// <param name="hWinSta">[in] Handle to the window
        ///         station to be assigned to the calling process</param>
        /// <returns>If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. </returns>
        [DllImport("User32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr SetProcessWindowStation(IntPtr hWinSta);
        /// <summary>
        /// Closes an open window station handle.
        /// </summary>
        /// <param name="hWinSta">[in] Handle
        ///         to the window station to be closed.</param>
        /// <returns>If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. </returns>
        [DllImport("User32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr CloseWindowStation(IntPtr hWinSta);
        /// <summary>
        /// Opens the specified desktop object.
        /// </summary>
        /// <param name="lpszDesktop">[in] Pointer to null-terminated string 
        /// specifying the name of the desktop to be opened. 
        /// Desktop names are case-insensitive.
        /// This desktop must belong to the current window station.</param>
        /// <param name="dwFlags">[in] This parameter can
        ///          be zero or DF_ALLOWOTHERACCOUNTHOOK=0x0001</param>
        /// <param name="fInherit">[in] If this value is TRUE, processes created by 
        /// this process will inherit the handle. 
        /// Otherwise, the processes do not inherit this handle. </param>
        /// <param name="dwDesiredAccess">[in] Access
        ///         to the desktop. For a list of access rights</param>
        /// <returns>If the function succeeds, the return value is a handle to the opened desktop. 
        /// When you are finished using the handle, call the CloseDesktop function to close it.
        /// If the function fails, the return value is NULL.
        /// </returns>
        [DllImport("User32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr OpenDesktop(string lpszDesktop
            , OpenDesktopFlag dwFlags
            , bool fInherit
            , DesktopAccessRight dwDesiredAccess
            );
        /// <summary>
        /// Closes an open handle to a desktop object.
        /// </summary>
        /// <param name="hDesktop">[in] Handle to the desktop to be closed.</param>
        /// <returns>If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. </returns>
        [DllImport("User32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr CloseDesktop(IntPtr hDesktop);
        /// <summary>
        /// Assigns the specified desktop to the calling thread. 
        /// All subsequent operations on the desktop use the access rights granted to the desktop.
        /// </summary>
        /// <param name="hDesktop">[in] Handle to the desktop
        ///           to be assigned to the calling thread.</param>
        /// <returns>If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. </returns>
        [DllImport("User32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern bool SetThreadDesktop(IntPtr hDesktop);
    }
    /// <summary>
    /// REF MSDN:Window Station Security and Access Rights
    /// ms-help://MS.MSDN.vAug06.en/dllproc/base/window_station_security_and_access_rights.htm
    /// </summary>
    [FlagsAttribute]
    public enum WindowStationAccessRight : uint
    {
        /// <summary>All possible access rights for the window station.</summary>
        WINSTA_ALL_ACCESS = 0x37F,
        /// <summary>Required to use the clipboard.</summary>
        WINSTA_ACCESSCLIPBOARD = 0x0004,
        /// <summary>Required to manipulate global atoms.</summary>
        WINSTA_ACCESSGLOBALATOMS = 0x0020,
        /// <summary>Required to create new desktop
        /// objects on the window station.</summary>
        WINSTA_CREATEDESKTOP = 0x0008,
        /// <summary>Required to enumerate existing desktop objects.</summary>
        WINSTA_ENUMDESKTOPS = 0x0001,
        /// <summary>Required for the window station to be enumerated.</summary>
        WINSTA_ENUMERATE = 0x0100,
        /// <summary>Required to successfully call the ExitWindows or ExitWindowsEx function. 
        /// Window stations can be shared by users and this access type can prevent other users 
        /// of a window station from logging off the window station owner.</summary>
        WINSTA_EXITWINDOWS = 0x0040,
        /// <summary>Required to read the attributes of a window station object. 
        /// This attribute includes color settings 
        /// and other global window station properties.</summary>
        WINSTA_READATTRIBUTES = 0x0002,
        /// <summary>Required to access screen contents.</summary>
        WINSTA_READSCREEN = 0x0200,
        /// <summary>Required to modify the attributes of 
        /// a window station object. 
        /// The attributes include color settings 
        /// and other global window station properties.</summary>
        WINSTA_WRITEATTRIBUTES = 0x0010,
    }
    /// <summary>
    /// OpenDesktop 2nd param
    /// </summary>
    public enum OpenDesktopFlag : uint
    {
        /// <summary>
        /// Default value
        /// </summary>
        DF_NONE = 0x0000,
        /// <summary>
        /// Allows processes running in other accounts on the desktop
        /// to set hooks in this process.
        /// </summary>
        DF_ALLOWOTHERACCOUNTHOOK = 0x0001,
    }
    /// <summary>
    /// REF MSDN:Desktop Security and Access Rights
    /// ms-help://MS.MSDN.vAug06.en/dllproc/base/desktop_security_and_access_rights.htm
    /// </summary>
    [FlagsAttribute]
    public enum DesktopAccessRight : uint
    {
        /// <summary>Required to create a menu on the desktop. </summary>
        DESKTOP_CREATEMENU = 0x0004,
        /// <summary>Required to create a window on the desktop. </summary>
        DESKTOP_CREATEWINDOW = 0x0002,
        /// <summary>Required for the desktop to be enumerated. </summary>
        DESKTOP_ENUMERATE = 0x0040,
        /// <summary>Required to establish any of the window hooks. </summary>
        DESKTOP_HOOKCONTROL = 0x0008,
        /// <summary>Required to perform journal playback on a desktop. </summary>
        DESKTOP_JOURNALPLAYBACK = 0x0020,
        /// <summary>Required to perform journal recording on a desktop. </summary>
        DESKTOP_JOURNALRECORD = 0x0010,
        /// <summary>Required to read objects on the desktop. </summary>
        DESKTOP_READOBJECTS = 0x0001,
        /// <summary>Required to activate the desktop
        ///          using the SwitchDesktop function. </summary>
        DESKTOP_SWITCHDESKTOP = 0x0100,
        /// <summary>Required to write objects on the desktop. </summary>
        DESKTOP_WRITEOBJECTS = 0x0080,
    }
