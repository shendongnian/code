            BrowserWindow bw = BrowserWindow.Launch(new Uri("http://www.google.com"));
            bw.WaitForControlReady();
            UITestControl document = bw.CurrentDocumentWindow;
            HtmlControl control = new HtmlControl(document);
            control.SearchProperties.Add(HtmlControl.PropertyNames.ClassName, "HtmlHyperlink");
            UITestControlCollection controlcollection = control.FindMatchingControls();
            List<string> names = new List<string>();
            foreach (UITestControl x in controlcollection)
            {
                if (x is HtmlHyperlink)
                {
                    HtmlHyperlink s = (HtmlHyperlink)x;
                    names.Add(s.Href);
                }
            }
