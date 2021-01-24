    public static class WindowRestorerService
    {
        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private static Encoding encoding = new UTF8Encoding();
        private static XmlSerializer serializer = new XmlSerializer(typeof(WINDOWPLACEMENT));
        [DllImport("user32.dll")]
        private static extern bool SetWindowPlacement(IntPtr hWnd, [In] ref WINDOWPLACEMENT lpwndpl);
        [DllImport("user32.dll")]
        private static extern bool GetWindowPlacement(IntPtr hWnd, out WINDOWPLACEMENT lpwndpl);
        public static void SetPlacement(this Window window, string placementXml)
        {
            WindowRestorerService.SetPlacement(new WindowInteropHelper(window).Handle, placementXml);
        }
        /// <summary>
        /// Set the window to the relevent position using the placement information. 
        /// </summary>
        /// <param name="windowHandle">The window handle of the target information.</param>
        /// <param name="placementXml">The placement XML.</param>
        public static void SetPlacement(IntPtr windowHandle, string placementXml)
        {
            if (string.IsNullOrEmpty(placementXml))
                return;
            WINDOWPLACEMENT placement;
            byte[] xmlBytes = encoding.GetBytes(placementXml);
            try
            {
                using (MemoryStream memoryStream = new MemoryStream(xmlBytes))
                {
                    placement = (WINDOWPLACEMENT)serializer.Deserialize(memoryStream);
                }
                placement.length = Marshal.SizeOf(typeof(WINDOWPLACEMENT));
                placement.flags = 0;
                placement.showCmd = (placement.showCmd == SW_SHOWMINIMIZED ? SW_SHOWNORMAL : placement.showCmd);
                SetWindowPlacement(windowHandle, ref placement);
            }
            catch (InvalidOperationException)
            {
                // Parsing placement XML failed. Fail silently.
            }
        }
        public static string GetPlacement(this Window window)
        {
            return WindowRestorerService.GetPlacement(new WindowInteropHelper(window).Handle);
        }
        /// <summary>
        /// Retruns the serialize XML of the placement information for the 
        /// target window.
        /// </summary>
        /// <param name="windowHandle">The handle of the target window.</param>
        public static string GetPlacement(IntPtr windowHandle)
        {
            WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
            GetWindowPlacement(windowHandle, out placement);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8))
                {
                    serializer.Serialize(xmlTextWriter, placement);
                    byte[] xmlBytes = memoryStream.ToArray();
                    return encoding.GetString(xmlBytes);
                }
            }
        }
    }
    
