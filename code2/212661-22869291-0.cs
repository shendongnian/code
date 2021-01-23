	        //Navigation Timer
            timer2.Enabled = true;
            timer2.Interval = 30000;
 	        br.DocumentCompleted += browser_DocumentCompleted;
            br.DocumentCompleted += writeToTextBoxEvent;
            br.Navigating += OnNavigating;
            br.Navigated  += OnNavigated;
            br.ScriptErrorsSuppressed = true;
            br.Navigate(ConfigValues.websiteUrl);
        private void OnNavigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            //Reset Timer
            timer2.Stop();
            timer2.Start();
            
            WriteLogFunction("OnNavigating||||||"+e.Url.ToString());
        }
        private void OnNavigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            //Stop Timer
            timer2.Stop();
            WriteLogFunction("NAVIGATED <><><><><><><> " + e.Url.ToString());
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            WriteLogFunction(" Navigation Timeout TICK");
            br.Stop();
            br.Navigate(ConfigValues.websiteUrl);
        }
