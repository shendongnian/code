     protected override void OnStartup(StartupEventArgs e)
        {
            if (e.Args != null && e.Args.Length > 0)
            {
                //MessageBox.Show("dgda");
                //DirectOpenPath = e.Args[0].ToString();
                this.Properties["ArbitraryArgName"] = e.Args[0];
            }
            base.OnStartup(e);
        }
