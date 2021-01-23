            var page = new TabPage(textBox1.Text);
            var browser = new WebBrowser();
            browser.Dock = DockStyle.Fill;
            page.Controls.Add(browser);
            tabControl1.TabPages.Add(page);
            browser.Navigate("http://stackoverflow.com");
            page.Select();
