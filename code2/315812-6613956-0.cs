            Browser.Navigate(sLetterFile);
            while (Browser.ReadyState != WebBrowserReadyState.Complete)
            {
                System.Windows.Forms.Application.DoEvents();
            }
            Thread.Sleep(1000);
            
