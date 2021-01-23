       void WaitBrowserLoading()
        {
            while (webBrowser1.IsBusy)
                Application.DoEvents();
            for (int i = 0; i < 500; i++)
                if (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(10);
                }
                else
                    break;
            Application.DoEvents();
        }
