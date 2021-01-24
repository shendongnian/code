    private async void GetPageHTML()
    {
        sHTMLSource = await webView1.InvokeScriptAsync("eval", new string[] { "document.documentElement.outerHTML;" });
    }
    
    private string sHTMLSource = null;
    private void webView1_NavigationCompleted(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlNavigationCompletedEventArgs e)
    {
        GetPageHTML();
    }
