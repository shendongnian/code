    void br1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var br1 = sender as WebBrowser;
            if (br1.Url == e.Url)
            {
                Console.WriteLine("Natigated to {0}", e.Url);
                Application.ExitThread();   // Stops the thread
            }
        }
