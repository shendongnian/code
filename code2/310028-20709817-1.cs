    using System;
    using System.Security.Permissions;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace SHDocVw
    {
        public delegate void WebBrowserNewWindow2EventHandler(object sender, WebBrowserNewWindow2EventArgs e);
    
        public class WebBrowserNewWindow2EventArgs : EventArgs
        {
            public WebBrowserNewWindow2EventArgs(object ppDisp, bool cancel)
            {
                PpDisp = ppDisp;
                Cancel = cancel;
            }
    
            public object PpDisp { get; set; }
            public bool Cancel { get; set; }
        }
    
        public class WebBrowserNewWindow2 : WebBrowser
        {
            private AxHost.ConnectionPointCookie _cookie;
            private WebBrowser2EventHelper _helper;
    
            [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
            protected override void CreateSink()
            {
                base.CreateSink();
    
                _helper = new WebBrowser2EventHelper(this);
                _cookie = new AxHost.ConnectionPointCookie(
                    this.ActiveXInstance, _helper, typeof(DWebBrowserEvents2));
            }
    
            [PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
            protected override void DetachSink()
            {
                if (_cookie != null)
                {
                    _cookie.Disconnect();
                    _cookie = null;
                }
                base.DetachSink();
            }
    
            public event WebBrowserNewWindow2EventHandler NewWindow2;
    
            private class WebBrowser2EventHelper : StandardOleMarshalObject, DWebBrowserEvents2
            {
                private readonly WebBrowserNewWindow2 _parent;
    
                public WebBrowser2EventHelper(WebBrowserNewWindow2 parent)
                {
                    _parent = parent;
                }
    
                public void NewWindow2(ref object pDisp, ref bool cancel)
                {
                    WebBrowserNewWindow2EventArgs arg = new WebBrowserNewWindow2EventArgs(pDisp, cancel);
                    _parent.NewWindow2(this, arg);
                    if (pDisp != arg.PpDisp)
                        pDisp = arg.PpDisp;
                    if (cancel != arg.Cancel)
                        cancel = arg.Cancel;
                }
            }
    
            [ComImport, Guid("34A715A0-6587-11D0-924A-0020AFC7AC4D"),
            InterfaceType(ComInterfaceType.InterfaceIsIDispatch),
            TypeLibType(TypeLibTypeFlags.FHidden)]
            public interface DWebBrowserEvents2
            {
                [DispId(0xfb)]
                void NewWindow2(
                    [In, Out, MarshalAs(UnmanagedType.IDispatch)] ref object ppDisp,
                    [In, Out] ref bool cancel);
            }
        }
    }
