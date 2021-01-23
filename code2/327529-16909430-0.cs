    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    public class ComputerBrowser
    {
        private FolderBrowserFolder _startLocation = FolderBrowserFolder.NetworkNeighborhood;
        private BrowseInfos _options = BrowseInfos.BrowseForComputer;
        private static readonly int MAX_PATH;
        private string _title;
        private string _displayName;
        private string _path;
        static ComputerBrowser()
        {
            MAX_PATH = 260;
        }
        public bool ShowDialog()
        {
            return ShowDialog(null);
        }
        public bool ShowDialog(IWin32Window owner)
        {
            _path = string.Empty;
            IntPtr handle;
            IntPtr zero = IntPtr.Zero;
            if (owner != null)
                handle = owner.Handle;
            else
                handle = UnmanagedMethods.GetActiveWindow();
            UnmanagedMethods.SHGetSpecialFolderLocation(handle, (int)_startLocation, ref zero);
            if (zero == IntPtr.Zero)
                return false;
            int num = (int)_options;
            if ((num & 0x40) != 0)
                Application.OleRequired();
            IntPtr pidl = IntPtr.Zero;
            try
            {
                BrowseInfo lpbi = new BrowseInfo();
                //IntPtr pszPath = Marshal.AllocHGlobal(MAX_PATH);
                lpbi.pidlRoot = zero;
                lpbi.hwndOwner = handle;
                lpbi.displayName = new string('\0', MAX_PATH);
                lpbi.title = _title;
                lpbi.flags = num;
                lpbi.callback = null;
                lpbi.lparam = IntPtr.Zero;
                pidl = UnmanagedMethods.SHBrowseForFolder(ref lpbi);
                if (pidl == IntPtr.Zero)
                    return false;
                _displayName = lpbi.displayName;
                StringBuilder pathReturned = new StringBuilder(MAX_PATH);
                UnmanagedMethods.SHGetPathFromIDList(pidl, pathReturned);
                _path = pathReturned.ToString();
                UnmanagedMethods.SHMemFree(pidl);
            }
            finally
            {
                UnmanagedMethods.SHMemFree(zero);
            }
            return true;
        }
        protected enum FolderBrowserFolder
        {
            Desktop = 0,
            Favorites = 6,
            MyComputer = 0x11,
            MyDocuments = 5,
            MyPictures = 0x27,
            NetAndDialUpConnections = 0x31,
            NetworkNeighborhood = 0x12,
            Printers = 4,
            Recent = 8,
            SendTo = 9,
            StartMenu = 11,
            Templates = 0x15
        }
        [Flags]
        public enum BrowseInfos
        {
            AllowUrls = 0x80,
            BrowseForComputer = 0x1000,
            BrowseForEverything = 0x4000,
            BrowseForPrinter = 0x2000,
            DontGoBelowDomain = 2,
            ShowTextBox = 0x10,
            NewDialogStyle = 0x40,
            RestrictToSubfolders = 8,
            RestrictToFilesystem = 1,
            ShowShares = 0x8000,
            StatusText = 4,
            UseNewUI = 80,
            Validate = 0x20
        }
        public static string GetComputerName(string title)
        {
            ComputerBrowser browser = new ComputerBrowser();
            browser._title = title;
            if (browser.ShowDialog())
                return browser._displayName;
            else
                return string.Empty;
        }
    }
