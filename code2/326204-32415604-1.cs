    AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(    
    (s, a) =>
    {
        if (a.Name.Substring(0, a.Name.IndexOf(",")) == "AxInterop.WMPLib")
        {
            return Assembly.Load(res.AxInterop_WMPLib);
        }
    
        if (a.Name.Substring(0, a.Name.IndexOf(",")) == "Interop.WMPLib")
        {
            return Assembly.Load(res.Interop_WMPLib);
        }
    
        return null;
    });
