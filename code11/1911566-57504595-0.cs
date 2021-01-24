    internal sealed class CollapsableChromiumWebBrowser : ChromiumWebBrowser
    {
        public CollapsableChromiumWebBrowser()
        {
            this.Loaded += this.CollapsableChromiumWebBrowser_Loaded;
        }
        private void CollapsableChromiumWebBrowser_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            // Avoid loading CEF in designer
            if (DesignerProperties.GetIsInDesignMode(this))
            {
                return;
            }
            // Avoid NRE in AbstractRenderHandler.OnPaint
            ApplyTemplate();
            // https://github.com/cefsharp/CefSharp/issues/1412
            CreateOffscreenBrowser(new Size(400, 400));
        }
    }
