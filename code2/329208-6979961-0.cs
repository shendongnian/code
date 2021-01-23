    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]   
    [Guid("6d5140c1-7436-11ce-8034-00aa006009fa")]  
    internal interface IServiceProvider   
    {
       [return: MarshalAs(UnmanagedType.IUnknown)]
       object QueryService(ref Guid guidService, ref Guid riid);
    }
    
    static readonly Guid SID_SWebBrowserApp = new Guid("0002DF05-0000-0000-C000-000000000046");   
    ...   
    IServiceProvider serviceProvider = (IServiceProvider)myWebBrowser.Document;
    Guid serviceGuid = SID_SWebBrowserApp;
    Guid iid = typeof(SHDocVw.IWebBrowser2).GUID;
    SHDocVw.IWebBrowser2 myWebBrowser2 = (SHDocVw.IWebBrowser2) serviceProvider.QueryService(ref serviceGuid, ref iid);
    ...
