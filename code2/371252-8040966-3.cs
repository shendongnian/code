        public int GetSite(ref Guid riid, out IntPtr ppvSite)
        {
            var pUnk = Marshal.GetIUnknownForObject(_pUnkSite);
            try
            {
                return Marshal.QueryInterface(pUnk, ref riid, out ppvSite);
            }
            finally
            {
                Marshal.Release(pUnk);
            }
        }
    In this case, `_pUnkSite` is the object that you were given at `SetSite`. So `SetSite` will look something like this:
        private object _pUnkSite;
        public int SetSite(object pUnkSite)
        {
            _pUnkSite = pUnkSite;
            //Cast pUnkSite to `IWebBrowser2` here and attach events.
            return 0;
        }
