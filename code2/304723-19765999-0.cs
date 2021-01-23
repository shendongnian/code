    class MsiHandle : SafeHandleMinusOneIsInvalid
    {
        public MsiHandle()
            : base(true)
        { }
        protected override bool ReleaseHandle()
        {
            return NativeMethods.MsiCloseHandle(handle) == 0;
        }
    }
    class NativeMethods
    {
        const string MsiDll = "Msi.dll";
        [DllImport(MsiDll, CharSet = CharSet.Unicode, ExactSpelling = true)]
        public extern static uint MsiOpenPackageW(string szPackagePath, out MsiHandle product);
        [DllImport(MsiDll, ExactSpelling=true)]
        public extern static uint MsiCloseHandle(IntPtr hAny);
        [DllImport(MsiDll, CharSet = CharSet.Unicode, ExactSpelling = true)]
        static extern uint MsiGetProductPropertyW(MsiHandle hProduct, string szProperty, StringBuilder value, ref int length);
        [DllImport(MsiDll, ExactSpelling = true)]
        public static extern int MsiSetInternalUI(int value, IntPtr hwnd);
        public static uint MsiGetProductProperty(MsiHandle hProduct, string szProperty, out string value)
        {
            StringBuilder sb = new StringBuilder(1024);
            int length = sb.Capacity;
            uint err;
            value = null;
            if(0 == (err = MsiGetProductPropertyW(hProduct, szProperty, sb, ref length)))
            {
                sb.Length = length;
                value = sb.ToString();
                return 0;
            }
            return err;
        }
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            string msiFile = args[0];
            NativeMethods.MsiSetInternalUI(2, IntPtr.Zero); // Hide all UI. Without this you get a MSI dialog
            MsiHandle msi;
            uint err;
            if (0 != (err = NativeMethods.MsiOpenPackageW(args[0], out msi)))
            {
                Console.Error.WriteLine("Can't open MSI, error {0}", err);
                return 1;
            }
            // Strings available in all MSIs
            string productCode;
            using (msi)
            {
               if (0 != NativeMethods.MsiGetProductProperty(msi, "ProductCode", out productCode))
                    throw new InvalidOperationException("Can't obtain product code");
               Console.WriteLine(productCode);
               return 0;
            }
        }
    }
