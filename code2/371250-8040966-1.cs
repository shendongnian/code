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
