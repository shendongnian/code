    class GetGuid
    {
        [DllImport("oleaut32.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        static extern int LoadTypeLib(string fileName, out ITypeLib typeLib);
        public string SearchRegistry(string dllPath /* or ocx */)
        {
            var result = string.Empty;
            ITypeLib tl;
            if (LoadTypeLib(dllPath, out tl) == 0)
            {
                ITypeInfo tf;
                tl.GetTypeInfo(0, out tf);
                var ip = IntPtr.Zero;
                tl.GetLibAttr(out ip);
                if (ip != IntPtr.Zero)
                {
                    var ta = (System.Runtime.InteropServices.ComTypes.TYPELIBATTR)Marshal.PtrToStructure(ip, typeof(System.Runtime.InteropServices.ComTypes.TYPELIBATTR));
                    result = ta.guid.ToString();
                }
            }
            return result;
        }
    }
