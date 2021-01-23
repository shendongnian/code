    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private IObjectWithSite _band = (IObjectWithSite)Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("{01E04581-4EEE-11d0-BFE9-00AA005B4383}")));
            private BandSite _site;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            protected override void CreateHandle()
            {
                base.CreateHandle();
                if (_site == null)
                {
                    _site = new BandSite(Handle);
                    _band.SetSite(_site);
                }
            }
    
            private class BandSite : IOleWindow
            {
                private IntPtr _hwnd;
    
                public BandSite(IntPtr hwnd)
                {
                    _hwnd = hwnd;
                }
    
                void IOleWindow.GetWindow(out IntPtr hwnd)
                {
                    hwnd = _hwnd;
                }
    
                void IOleWindow.ContextSensitiveHelp(int fEnterMode)
                {
                    throw new NotImplementedException();
                }
            }
        }
    
        [ComImport, Guid("FC4801A3-2BA9-11CF-A229-00AA003D7352"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IObjectWithSite
        {
            void SetSite([MarshalAs(UnmanagedType.IUnknown)] object pUnkSite);
    
            [return: MarshalAs(UnmanagedType.IUnknown)]
            object GetSite(ref Guid riid);
        }
    
        [ComImport, Guid("00000114-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IOleWindow
        {
            void GetWindow(out IntPtr hwnd);
            void ContextSensitiveHelp(int fEnterMode);
        }
    }
