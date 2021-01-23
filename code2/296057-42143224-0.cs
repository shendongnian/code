        /// <summary>
        /// Gets an interop web browser.
        /// </summary>
        /// <param name="browser"></param>
        /// <returns></returns>
        public static SHDocVw.WebBrowser GetInteropWebBrowser(this WebBrowser browser)
        {
            Guid serviceGuid = new Guid("0002DF05-0000-0000-C000-000000000046");
            Guid iid = typeof(SHDocVw.IWebBrowser2).GUID;
            Interop.IServiceProvider serviceProvider = (Interop.IServiceProvider)browser.Document;
            SHDocVw.IWebBrowser2 browser2 = (SHDocVw.IWebBrowser2)serviceProvider.QueryService(ref serviceGuid, ref iid);
            SHDocVw.WebBrowser wb = (SHDocVw.WebBrowser)browser2;
            return wb;
        }
        /// <summary>
        /// Disables script errors for the browser.
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="silent"></param>
        public static void SetSilent(this WebBrowser browser, bool silent)
        {
            SHDocVw.WebBrowser browser2 = browser.GetInteropWebBrowser();
            if (browser2 != null)
                browser2.Silent = silent;
        }
    /// <summary>
    /// Provides the COM interface for the IServiceProvider.
    /// </summary>
    [ComImport, Guid("6D5140C1-7436-11CE-8034-00AA006009FA"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IServiceProvider
    {
        /// <summary>
        /// Queries the service.
        /// </summary>
        /// <param name="serviceGuid"></param>
        /// <param name="riid"></param>
        /// <returns></returns>
        [return: MarshalAs(UnmanagedType.IUnknown)]
        object QueryService(ref Guid serviceGuid, ref Guid riid);
    }
