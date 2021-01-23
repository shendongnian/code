        // test code
        private void button1_Click(object sender, EventArgs e)
        {
            _events = new WebBrowserEvents(_wb); // register event sink, make sure ActiveXInsance is not null here
            _wb.Navigate("http://www.popuptest.com/");
        }
    // this event sink declares the NewWindow3 event
    public class WebBrowserEvents : StandardOleMarshalObject, DWebBrowserEvents2, IDisposable
    {
        private AxHost.ConnectionPointCookie _cookie;
        public WebBrowserEvents(WebBrowser wb)
        {
            _cookie = new AxHost.ConnectionPointCookie(wb.ActiveXInstance, this, typeof(DWebBrowserEvents2));
        }
        void DWebBrowserEvents2.StatusTextChange(string text)
        {
            Trace.WriteLine("StatusTextChange text:" + text);
        }
        void DWebBrowserEvents2.ProgressChange(int progress, int progressMax)
        {
            Trace.WriteLine("ProgressChange progress:" + progress + " progress:" + progressMax);
        }
        void DWebBrowserEvents2.CommandStateChange(int command, bool enable)
        {
            Trace.WriteLine("CommandStateChange command:" + command + " enable:" + enable);
        }
        void DWebBrowserEvents2.DownloadBegin()
        {
            Trace.WriteLine("DownloadBegin");
        }
        void DWebBrowserEvents2.DownloadComplete()
        {
            Trace.WriteLine("DownloadComplete");
        }
        void DWebBrowserEvents2.TitleChange(string text)
        {
            Trace.WriteLine("TitleChange text:" + text);
        }
        void DWebBrowserEvents2.PropertyChange(string szProperty)
        {
            Trace.WriteLine("PropertyChange szProperty:" + szProperty);
        }
        void DWebBrowserEvents2.BeforeNavigate2(object pDisp, ref object URL, ref object flags, ref object targetFrameName, ref object postData, ref object headers, ref bool cancel)
        {
            Trace.WriteLine("BeforeNavigate2 URL:" + URL);
        }
        void DWebBrowserEvents2.NewWindow2(ref object pDisp, ref bool cancel)
        {
            Trace.WriteLine("NewWindow2");
        }
        void DWebBrowserEvents2.NavigateComplete2(object pDisp, ref object URL)
        {
            Trace.WriteLine("NavigateComplete2 URL:" + URL);
        }
        void DWebBrowserEvents2.DocumentComplete(object pDisp, ref object URL)
        {
            Trace.WriteLine("DocumentComplete URL:" + URL);
        }
        void DWebBrowserEvents2.OnQuit()
        {
            Trace.WriteLine("OnQuit");
        }
        void DWebBrowserEvents2.OnVisible(bool visible)
        {
            Trace.WriteLine("OnVisible visible:" + visible);
        }
        void DWebBrowserEvents2.OnToolBar(bool toolBar)
        {
            Trace.WriteLine("OnToolBar toolBar:" + toolBar);
        }
        void DWebBrowserEvents2.OnMenuBar(bool menuBar)
        {
            Trace.WriteLine("OnMenuBar menuBar:" + menuBar);
        }
        void DWebBrowserEvents2.OnStatusBar(bool statusBar)
        {
            Trace.WriteLine("OnStatusBar statusBar:" + statusBar);
        }
        void DWebBrowserEvents2.OnFullScreen(bool fullScreen)
        {
            Trace.WriteLine("OnFullScreen fullScreen:" + fullScreen);
        }
        void DWebBrowserEvents2.OnTheaterMode(bool theaterMode)
        {
            Trace.WriteLine("OnTheaterMode theaterMode:" + theaterMode);
        }
        void DWebBrowserEvents2.WindowSetResizable(bool resizable)
        {
            Trace.WriteLine("WindowSetResizable resizable:" + resizable);
        }
        void DWebBrowserEvents2.WindowSetLeft(int left)
        {
            Trace.WriteLine("WindowSetLeft left:" + left);
        }
        void DWebBrowserEvents2.WindowSetTop(int top)
        {
            Trace.WriteLine("WindowSetTop top:" + top);
        }
        void DWebBrowserEvents2.WindowSetWidth(int width)
        {
            Trace.WriteLine("WindowSetWidth width:" + width);
        }
        void DWebBrowserEvents2.WindowSetHeight(int height)
        {
            Trace.WriteLine("WindowSetHeight height:" + height);
        }
        void DWebBrowserEvents2.WindowClosing(bool isChildWindow, ref bool cancel)
        {
            Trace.WriteLine("WindowClosing isChildWindow:" + isChildWindow);
        }
        void DWebBrowserEvents2.ClientToHostWindow(ref int cx, ref int cy)
        {
            Trace.WriteLine("ClientToHostWindow cx:" + cx + " cy:" + cy);
        }
        void DWebBrowserEvents2.SetSecureLockIcon(int secureLockIcon)
        {
            Trace.WriteLine("SetSecureLockIcon secureLockIcon:" + secureLockIcon);
        }
        void DWebBrowserEvents2.FileDownload(ref bool cancel)
        {
            Trace.WriteLine("FileDownload");
        }
        void DWebBrowserEvents2.NavigateError(object pDisp, ref object URL, ref object frame, ref object statusCode, ref bool cancel)
        {
            Trace.WriteLine("NavigateError url:" + URL);
        }
        void DWebBrowserEvents2.PrintTemplateInstantiation(object pDisp)
        {
            Trace.WriteLine("PrintTemplateInstantiation");
        }
        void DWebBrowserEvents2.PrintTemplateTeardown(object pDisp)
        {
            Trace.WriteLine("PrintTemplateTeardown");
        }
        void DWebBrowserEvents2.UpdatePageStatus(object pDisp, ref object nPage, ref object fDone)
        {
            Trace.WriteLine("UpdatePageStatus");
        }
        void DWebBrowserEvents2.PrivacyImpactedStateChange(bool bImpacted)
        {
            Trace.WriteLine("PrivacyImpactedStateChange bImpacted:" + bImpacted);
        }
        void DWebBrowserEvents2.NewWindow3(ref object pDisp, ref bool cancel, int dwFlags, ref object bstrUrlContext, ref object bstrUrl)
        {
            Trace.WriteLine("NewWindow3 bstrUrlContext:" + bstrUrlContext + " bstrUrl:" + bstrUrl);
        }
        public void Dispose()
        {
            if (_cookie != null)
            {
                _cookie.Disconnect();
                _cookie = null;
            }
        }
    }
    [ComImport, Guid("34A715A0-6587-11D0-924A-0020AFC7AC4D"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    internal interface DWebBrowserEvents2
    {
        [DispId(0x66)]
        void StatusTextChange([In] string text);
        [DispId(0x6c)]
        void ProgressChange([In] int progress, [In] int progressMax);
        [DispId(0x69)]
        void CommandStateChange([In] int command, [In] bool enable);
        [DispId(0x6a)]
        void DownloadBegin();
        [DispId(0x68)]
        void DownloadComplete();
        [DispId(0x71)]
        void TitleChange([In] string text);
        [DispId(0x70)]
        void PropertyChange([In] string szProperty);
        [DispId(250)]
        void BeforeNavigate2([In, MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In] ref object URL, [In] ref object flags, [In] ref object targetFrameName, [In] ref object postData, [In] ref object headers, [In, Out] ref bool cancel);
        [DispId(0xfb)]
        void NewWindow2([In, Out, MarshalAs(UnmanagedType.IDispatch)] ref object pDisp, [In, Out] ref bool cancel);
        [DispId(0xfc)]
        void NavigateComplete2([In, MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In] ref object URL);
        [DispId(0x103)]
        void DocumentComplete([In, MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In] ref object URL);
        [DispId(0xfd)]
        void OnQuit();
        [DispId(0xfe)]
        void OnVisible([In] bool visible);
        [DispId(0xff)]
        void OnToolBar([In] bool toolBar);
        [DispId(0x100)]
        void OnMenuBar([In] bool menuBar);
        [DispId(0x101)]
        void OnStatusBar([In] bool statusBar);
        [DispId(0x102)]
        void OnFullScreen([In] bool fullScreen);
        [DispId(260)]
        void OnTheaterMode([In] bool theaterMode);
        [DispId(0x106)]
        void WindowSetResizable([In] bool resizable);
        [DispId(0x108)]
        void WindowSetLeft([In] int left);
        [DispId(0x109)]
        void WindowSetTop([In] int top);
        [DispId(0x10a)]
        void WindowSetWidth([In] int width);
        [DispId(0x10b)]
        void WindowSetHeight([In] int height);
        [DispId(0x107)]
        void WindowClosing([In] bool isChildWindow, [In, Out] ref bool cancel);
        [DispId(0x10c)]
        void ClientToHostWindow([In, Out] ref int cx, [In, Out] ref int cy);
        [DispId(0x10d)]
        void SetSecureLockIcon([In] int secureLockIcon);
        [DispId(270)]
        void FileDownload([In, Out] ref bool cancel);
        [DispId(0x10f)]
        void NavigateError([In, MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In] ref object URL, [In] ref object frame, [In] ref object statusCode, [In, Out] ref bool cancel);
        [DispId(0xe1)]
        void PrintTemplateInstantiation([In, MarshalAs(UnmanagedType.IDispatch)] object pDisp);
        [DispId(0xe2)]
        void PrintTemplateTeardown([In, MarshalAs(UnmanagedType.IDispatch)] object pDisp);
        [DispId(0xe3)]
        void UpdatePageStatus([In, MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In] ref object nPage, [In] ref object fDone);
        [DispId(0x110)]
        void PrivacyImpactedStateChange([In] bool bImpacted);
        [DispId(0x111)]
        void NewWindow3([In, Out, MarshalAs(UnmanagedType.IDispatch)] ref object pDisp, [In, Out] ref bool cancel, [In] int dwFlags, [In] ref object bstrUrlContext, [In] ref object bstrUrl);
    }
