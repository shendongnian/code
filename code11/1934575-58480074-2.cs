        private void WebView1_DOMContentLoaded(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlDOMContentLoadedEventArgs e)
            {
                String func = @" document.addEventListener('click', function(e){
    	                         //Get the Div Tag Name and its ID as string back into our code
                                 window.external.notify(e.target.tagName + '(' + e.target.id + ')');
                                });";
                webView1.InvokeScriptAsync("eval", func);
            }
    
            private void WebView1_ScriptNotify(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlScriptNotifyEventArgs e)
            {
                string s = e.Value; //This will give you the Div Tag Name and ID
            }
