    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Security.Permissions;
    using System.Windows.Forms;
    namespace MP.Assistant.WpfClient.DialogContentControls
    {
        /// Imports the BeforeNavigate2 method from the OLE DWebBrowserEvents2 
        /// interface. 
        [ComImport]
        [Guid("34A715A0-6587-11D0-924A-0020AFC7AC4D")]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [TypeLibType(TypeLibTypeFlags.FHidden)]
        public interface DWebBrowserEvents2
        {
            [PreserveSig]
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType =    MethodCodeType.Runtime)]
        [DispId(250)] 
        void BeforeNavigate2([In] [MarshalAs(UnmanagedType.IDispatch)] object pDisp,
                             [In] [MarshalAs(UnmanagedType.Struct)] ref object URL,
                             [In] [MarshalAs(UnmanagedType.Struct)] ref object Flags,
                             [In] [MarshalAs(UnmanagedType.Struct)] ref object TargetFrameName,
                             [In] [MarshalAs(UnmanagedType.Struct)] ref object PostData,
                             [In] [MarshalAs(UnmanagedType.Struct)] ref object Headers,
                             [In] [Out] ref bool Cancel);
    }
    public class ExtendedWinFormsWebBrowser : WebBrowser
    {
        // Handles the NavigateError event from the underlying ActiveX 
        // control by raising the NavigateError event defined in this class.
        AxHost.ConnectionPointCookie cookie;
        ExtendedWinFormsWebBrowserEventHelper helper;
        bool renavigating;
        public ExtendedWinFormsWebBrowser()
        {
            AdditionalHeaders = new string[] {};
        }
        public string[] AdditionalHeaders { get; set; }
        [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
        protected override void CreateSink()
        {
            base.CreateSink();
            // Create an instance of the client that will handle the event
            // and associate it with the underlying ActiveX control.
            helper = new ExtendedWinFormsWebBrowserEventHelper(this);
            cookie = new AxHost.ConnectionPointCookie(ActiveXInstance, helper, typeof (DWebBrowserEvents2));
        }
        [PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
        protected override void DetachSink()
        {
            // Disconnect the client that handles the event
            // from the underlying ActiveX control.
            if (cookie != null)
            {
                cookie.Disconnect();
                cookie = null;
            }
            base.DetachSink();
        }
        void OnBeforeNavigate2(object pDisp,
                               ref object url,
                               ref object flags,
                               ref object targetFrameName,
                               ref object postData,
                               ref object headers,
                               ref bool cancel)
        {
            if (!renavigating)
            {
                if (AdditionalHeaders.Length > 0)
                {
                    headers += string.Join("\r\n", AdditionalHeaders) + "\r\n";
                    renavigating = true;
                    cancel = true;
                    Navigate((string)url, (string)targetFrameName, (byte[])postData, (string)headers);
                }
            }
            else
            {
                renavigating = false;
            }
        }
        #region Nested type: ExtendedWinFormsWebBrowserEventHelper
        class ExtendedWinFormsWebBrowserEventHelper : StandardOleMarshalObject, DWebBrowserEvents2
        {
            readonly ExtendedWinFormsWebBrowser parent;
            public ExtendedWinFormsWebBrowserEventHelper(ExtendedWinFormsWebBrowser parent)
            {
                this.parent = parent;
            }
            #region DWebBrowserEvents2 Members
            public void BeforeNavigate2(object pDisp,
                                        ref object URL,
                                        ref object Flags,
                                        ref object TargetFrameName,
                                        ref object PostData,
                                        ref object Headers,
                                        ref bool Cancel)
            {
                parent.OnBeforeNavigate2(pDisp,
                    ref URL,
                    ref Flags,
                    ref TargetFrameName,
                    ref PostData,
                    ref Headers,
                    ref Cancel);
            }
            #endregion
        }
        #endregion
    }
    }
