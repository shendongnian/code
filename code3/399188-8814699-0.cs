        void webBrowser1_Navigating(object sender, NavigatingEventArgs e)
        {
            String scheme = null;
            
            try
            {
                scheme = e.Uri.Scheme;
            }
            catch
            {
            }
            if (scheme == null || scheme == "file")
                return;
            // Not going to follow any other link
            e.Cancel = true;
            if (scheme == "http")
            {
                // Check if it's the "shared" URL
                if (e.Uri.Host == "shared")
                {
                    // Start email
                    EmailComposeTask emailComposeTask = new EmailComposeTask();
                    emailComposeTask.Subject = "Sharing an app with you";
                    emailComposeTask.Body = "You may like this app...";
                    emailComposeTask.Show();
                }
                else
                {
                    // start it in Internet Explorer
                    WebBrowserTask webBrowserTask = new WebBrowserTask();
                    webBrowserTask.Uri = new Uri(e.Uri.AbsoluteUri);
                    webBrowserTask.Show();
                }
            }
            if (scheme == "mailto")
            {
                EmailComposeTask emailComposeTask = new EmailComposeTask();
                emailComposeTask.To = e.Uri.AbsoluteUri;
                emailComposeTask.Show();
            }
        }
