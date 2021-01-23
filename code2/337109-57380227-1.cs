    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.ComTypes;
    using SHDocVw;
    public static class WebBrowserExtensions
    {
        public static void SetHtmlContent(this System.Windows.Forms.WebBrowser webBrowser, string html, string baseUrl)
        {
            webBrowser.Navigate("about:blank");
            var browser = (IWebBrowser2)webBrowser.ActiveXInstance;
            var result = CreateStreamOnHGlobal(Marshal.StringToHGlobalAuto(html), true, out IStream stream);
            if ((result != 0) || (stream == null))
                return;
            var persistentMoniker = browser.Document as IPersistMoniker;
            if (persistentMoniker == null)
                return;
            IBindCtx bindContext = null;
            CreateBindCtx((uint)0, out bindContext);
            if (bindContext == null)
                return;
            var loader = new Moniker(baseUrl, html);
            persistentMoniker.Load(1, loader, bindContext, (uint)0);
            stream = null;
        }
    
        [DllImport("ole32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        static extern int CreateStreamOnHGlobal(IntPtr hGlobal, bool fDeleteOnRelease, out IStream istream);
        [DllImport("ole32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        static extern int CreateBindCtx([MarshalAs(UnmanagedType.U4)] uint dwReserved, [Out, MarshalAs(UnmanagedType.Interface)] out IBindCtx ppbc);
    
        [ComImport, ComVisible(true)]
        [Guid("79EAC9C9-BAF9-11CE-8C82-00AA004BA90B")]
        [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
        interface IPersistMoniker
        {
            void GetClassID([In, Out] ref Guid pClassID);
            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int IsDirty();
            void Load([In] int fFullyAvailable, [In, MarshalAs(UnmanagedType.Interface)] IMoniker pmk, [In, MarshalAs(UnmanagedType.Interface)] Object pbc, [In, MarshalAs(UnmanagedType.U4)] uint grfMode);
            void SaveCompleted([In, MarshalAs(UnmanagedType.Interface)] IMoniker pmk, [In, MarshalAs(UnmanagedType.Interface)] Object pbc);
            [return: MarshalAs(UnmanagedType.Interface)]
            IMoniker GetCurMoniker();
        }
        class Moniker : IMoniker
        {
            public static Guid IID_IStream = new Guid("0000000c-0000-0000-C000-000000000046");
            string baseUrl;
            IStream stream;
            public Moniker(string baseUrl, string content)
            {
                this.baseUrl = baseUrl;
                CreateStreamOnHGlobal(Marshal.StringToHGlobalAuto(content), true, out stream);
            }
            public void GetDisplayName(IBindCtx pbc, IMoniker pmkToLeft, out string ppszDisplayName)
            {
                ppszDisplayName = this.baseUrl;
            }
            public void BindToStorage(IBindCtx pbc, IMoniker pmkToLeft, ref Guid riid, out object ppvObj)
            {
                ppvObj = null;
                if (riid.Equals(IID_IStream))
                    ppvObj = (IStream)stream; ;
            }
            public void GetClassID(out Guid pClassID)
            {
                throw new NotImplementedException();
            }
            public int IsDirty()
            {
                throw new NotImplementedException();
            }
            public void Load(IStream pStm)
            {
                throw new NotImplementedException();
            }
            public void Save(IStream pStm, bool fClearDirty)
            {
                throw new NotImplementedException();
            }
            public void GetSizeMax(out long pcbSize)
            {
                throw new NotImplementedException();
            }
            public void BindToObject(IBindCtx pbc, IMoniker pmkToLeft, ref Guid riidResult, out object ppvResult)
            {
                throw new NotImplementedException();
            }
            public void Reduce(IBindCtx pbc, int dwReduceHowFar, ref IMoniker ppmkToLeft, out IMoniker ppmkReduced)
            {
                throw new NotImplementedException();
            }
            public void ComposeWith(IMoniker pmkRight, bool fOnlyIfNotGeneric, out IMoniker ppmkComposite)
            {
                throw new NotImplementedException();
            }
            public void Enum(bool fForward, out IEnumMoniker ppenumMoniker)
            {
                throw new NotImplementedException();
            }
            public int IsEqual(IMoniker pmkOtherMoniker)
            {
                throw new NotImplementedException();
            }
            public void Hash(out int pdwHash)
            {
                throw new NotImplementedException();
            }
            public int IsRunning(IBindCtx pbc, IMoniker pmkToLeft, IMoniker pmkNewlyRunning)
            {
                throw new NotImplementedException();
            }
            public void GetTimeOfLastChange(IBindCtx pbc, IMoniker pmkToLeft, out System.Runtime.InteropServices.ComTypes.FILETIME pFileTime)
            {
                throw new NotImplementedException();
            }
            public void Inverse(out IMoniker ppmk)
            {
                throw new NotImplementedException();
            }
            public void CommonPrefixWith(IMoniker pmkOther, out IMoniker ppmkPrefix)
            {
                throw new NotImplementedException();
            }
            public void RelativePathTo(IMoniker pmkOther, out IMoniker ppmkRelPath)
            {
                throw new NotImplementedException();
            }
            public void ParseDisplayName(IBindCtx pbc, IMoniker pmkToLeft, string pszDisplayName, out int pchEaten, out IMoniker ppmkOut)
            {
                throw new NotImplementedException();
            }
            public int IsSystemMoniker(out int pdwMksys)
            {
                throw new NotImplementedException();
            }
        }
    }
