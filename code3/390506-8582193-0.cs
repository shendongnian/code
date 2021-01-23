        private string getDefaultBrowser()
        {
            string browser = string.Empty;
            RegistryKey key = null;
            try
            {
                key = Registry.ClassesRoot.OpenSubKey(@"HTTP\shell\open\command", false);
                //trim off quotes
                browser = key.GetValue(null).ToString().ToLower().Replace("\"", "");
                if (!browser.EndsWith("exe"))
                {
                    //get rid of everything after the ".exe"
                    browser = browser.Substring(0, browser.LastIndexOf(".exe") + 4);
                }
            }
            finally
            {
                if (key != null) key.Close();
            }
            return browser;
        }
        private void lvWeb_MouseUp(object sender, MouseEventArgs e)
        {
            var hit = lvWeb.HitTest(e.Location);
            if (hit.SubItem != null && hit.SubItem == hit.Item.SubItems[1])
            {
                var url = new Uri(hit.SubItem.Text);
                //System.Diagnostics.Process.Start(url.ToString());
                Process p = new Process();
                p.StartInfo.FileName = getDefaultBrowser();
                p.StartInfo.Arguments = url.ToString();
                p.Start();
            }
        }
