                Browser.ProgressChanged += Browser_ProgressChanged;
    ...
    
            void Browser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e) {
                if (e.MaximumProgress > 0) {
                    int prog = (int)(100 * e.CurrentProgress / e.MaximumProgress);
                    progressBar1.Value = prog;
                }
            }
