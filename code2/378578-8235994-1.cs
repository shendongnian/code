        var thread = new System.Threading.Thread(p =>
        {
            lock (YourTabControl)
            {
                Action action = () =>
                {
                    addTab(url);
                };
                this.Invoke(action);
                if(url.Host == "google")
                    System.Threading.Thread.Sleep(5000);
            }
        });
        thread.Start();
