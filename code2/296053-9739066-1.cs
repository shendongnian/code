    using System;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;
    
    namespace MyApplication.Behaviors
    {
        public class WebBrowserBehavior
        {
            private static readonly Type OwnerType = typeof (WebBrowserBehavior);
    
            #region BindableSource
    
            public static readonly DependencyProperty BindableSourceProperty =
                DependencyProperty.RegisterAttached(
                    "BindableSource", 
                    typeof(string), 
                    OwnerType, 
                    new UIPropertyMetadata(OnBindableSourcePropertyChanged));
    
            [AttachedPropertyBrowsableForType(typeof(WebBrowser))]
            public static string GetBindableSource(DependencyObject obj)
            {
                return (string)obj.GetValue(BindableSourceProperty);
            }
    
            [AttachedPropertyBrowsableForType(typeof(WebBrowser))]
            public static void SetBindableSource(DependencyObject obj, string value)
            {
                obj.SetValue(BindableSourceProperty, value);
            }
    
            public static void OnBindableSourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var browser = d as WebBrowser;
                if (browser == null) return;
    
                browser.Source = (e.NewValue != null) ? new Uri(e.NewValue.ToString()) : null;
            }
    
            #endregion
    
            #region DisableJavascriptErrors
    
            #region SilentJavascriptErrorsContext (private DP)
    
            private static readonly DependencyPropertyKey SilentJavascriptErrorsContextKey =
                DependencyProperty.RegisterAttachedReadOnly(
                    "SilentJavascriptErrorsContext",
                    typeof (SilentJavascriptErrorsContext),
                    OwnerType,
                    new FrameworkPropertyMetadata(null));
    
            private static void SetSilentJavascriptErrorsContext(DependencyObject depObj, SilentJavascriptErrorsContext value)
            {
                depObj.SetValue(SilentJavascriptErrorsContextKey, value);
            }
    
            private static SilentJavascriptErrorsContext GetSilentJavascriptErrorsContext(DependencyObject depObj)
            {
                return (SilentJavascriptErrorsContext) depObj.GetValue(SilentJavascriptErrorsContextKey.DependencyProperty);
            }
    
            #endregion
    
            public static readonly DependencyProperty DisableJavascriptErrorsProperty =
                DependencyProperty.RegisterAttached(
                    "DisableJavascriptErrors",
                    typeof (bool),
                    OwnerType,
                    new FrameworkPropertyMetadata(OnDisableJavascriptErrorsChangedCallback));
    
            [AttachedPropertyBrowsableForType(typeof(WebBrowser))]
            public static void SetDisableJavascriptErrors(DependencyObject depObj, bool value)
            {
                depObj.SetValue(DisableJavascriptErrorsProperty, value);
            }
    
            [AttachedPropertyBrowsableForType(typeof(WebBrowser))]
            public static bool GetDisableJavascriptErrors(DependencyObject depObj)
            {
                return (bool)depObj.GetValue(DisableJavascriptErrorsProperty);
            }
    
            private static void OnDisableJavascriptErrorsChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var webBrowser = d as WebBrowser;
                if (webBrowser == null) return;
                if (Equals(e.OldValue, e.NewValue)) return;
    
                var context = GetSilentJavascriptErrorsContext(webBrowser);
                if (context != null) {
                    context.Dispose();
                }
    
                if (e.NewValue != null) {
                    context = new SilentJavascriptErrorsContext(webBrowser);
                    SetSilentJavascriptErrorsContext(webBrowser, context);
                }
                else {
                    SetSilentJavascriptErrorsContext(webBrowser, null);
                }
            }
    
            private class SilentJavascriptErrorsContext : IDisposable
            {
                private bool? _silent; 
                private readonly WebBrowser _webBrowser;
    
    
                public SilentJavascriptErrorsContext(WebBrowser webBrowser)
                {
                    _silent = new bool?();
    
                    _webBrowser = webBrowser;
                    _webBrowser.Loaded += OnWebBrowserLoaded;
                    _webBrowser.Navigated += OnWebBrowserNavigated;
                }
    
                private void OnWebBrowserLoaded(object sender, RoutedEventArgs e)
                {
                    if (!_silent.HasValue) return;
    
                    SetSilent();
                }
    
                private void OnWebBrowserNavigated(object sender, NavigationEventArgs e)
                {
                    var webBrowser = (WebBrowser)sender;
    
                    if (!_silent.HasValue) {
                        _silent = GetDisableJavascriptErrors(webBrowser);
                    }
    
                    if (!webBrowser.IsLoaded) return;
    
                    SetSilent();
                }
    
                /// <summary>
                /// Solution by Simon Mourier on StackOverflow
                /// http://stackoverflow.com/a/6198700/741414
                /// </summary>
                private void SetSilent()
                {
                    _webBrowser.Loaded -= OnWebBrowserLoaded;
                    _webBrowser.Navigated -= OnWebBrowserNavigated;
    
                    // get an IWebBrowser2 from the document
                    var sp = _webBrowser.Document as IOleServiceProvider;
                    if (sp != null)
                    {
                        var IID_IWebBrowserApp = new Guid("0002DF05-0000-0000-C000-000000000046");
                        var IID_IWebBrowser2 = new Guid("D30C1661-CDAF-11d0-8A3E-00C04FC9E26E");
    
                        object webBrowser2;
                        sp.QueryService(ref IID_IWebBrowserApp, ref IID_IWebBrowser2, out webBrowser2);
                        if (webBrowser2 != null)
                        {
                            webBrowser2.GetType().InvokeMember(
                                "Silent",
                                BindingFlags.Instance | BindingFlags.Public | BindingFlags.PutDispProperty,
                                null,
                                webBrowser2,
                                new object[] { _silent });
                        }
                    }
                }
    
                [ComImport, Guid("6D5140C1-7436-11CE-8034-00AA006009FA"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
                private interface IOleServiceProvider
                {
                    [PreserveSig]
                    int QueryService([In] ref Guid guidService, [In] ref Guid riid, [MarshalAs(UnmanagedType.IDispatch)] out object ppvObject);
                }
    
                public void Dispose()
                {
                    if (_webBrowser != null) {
                        _webBrowser.Loaded -= OnWebBrowserLoaded;
                        _webBrowser.Navigated -= OnWebBrowserNavigated;
                    }
                }
            }
    
            #endregion
    
        }
    }
