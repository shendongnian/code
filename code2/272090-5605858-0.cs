                Process internetBrowserProcess = new Process();
    
                ProcessStartInfo psiOjbect = new ProcessStartInfo("http://DefaultWebsiteOfmyCompany.com"); // You can also use "about:blank".
    
                internetBrowserProcess.StartInfo = psiOjbect;
                internetBrowserProcess.Start();
                Thread.Sleep(2000); //Need to wait a little till the slow IE browser opens up.
    
                foreach (string websiteUrl in Properties.Settings.Default.WebSiteURLs)
                {
                    Process.Start(websiteUrl );
                }
