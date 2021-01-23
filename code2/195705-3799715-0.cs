    //Create the instance of new webbrowser control.
            WebBrowser browser = new WebBrowser();
            //Navigate to the specified URL.
            browser.Navigate(@"test.html");
            //Wait until the webpage gets loaded completely.
            while (browser.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            
            foreach (object divElement in
                (browser.Document.GetElementsByTagName("div")))
            {
                IHTMLCurrentStyle currentStyle = ((divElement as HtmlElement)
                    .DomElement as IHTMLElement2).currentStyle;
                Console.WriteLine(currentStyle.marginLeft);
                Console.WriteLine(currentStyle.marginRight);
            }
