            // add progress bar
            private ProgressBar progressBar1;
            //create event for ProgressChanged 
            Browser.ProgressChanged += Browser_ProgressChanged;
            ...
            // set progress bar value when ProgressChanged event firing 
            void Browser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e) {
            if (e.MaximumProgress > 0) {
                int prog = (int)(100 * e.CurrentProgress / e.MaximumProgress);
                progressBar1.Value = prog;
            }
        }
