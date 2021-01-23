            WebBrowser browser = new WebBrowser();
            browser.Navigate("http://www.stackoverflow.com");
            while (browser.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            HtmlPaginator pagr = new HtmlPaginator();
            pagr.PageReady += new EventHandler<HtmlPaginator.PageImageEventArgs>(pagr_PageReady);
            pagr.GeneratePages(browser.DocumentText);
