        private void OnStartUp(object sender, StartupEventArgs e)
        {
            OnStartup(e);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow mw = new MainWindow();
            
            if (e.Args != null && e.Args.Count() > 0)
            {
                this.Properties["ArbitraryArgName"] = e.Args[0];
            }
            //base.OnStartup(e);
            if (Application.Current.Properties["ArbitraryArgName"] != null)
            {               
                string fname = Application.Current.Properties["ArbitraryArgName"].ToString();
                mw.Show();
                mw.readVcard(fname);
                //Application curApp = Application.Current;
                //curApp.Shutdown();
            }
            else if (e.Args.Count() == 0)
            {
                mw.Show();
            }
        }
