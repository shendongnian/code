        protected override void OnStartup(StartupEventArgs e)
        {
            if (this.IsOneTimeLaunch())
            {
                base.OnStartup(e);
            }
            else
            {
                this.Shutdown();
            }
        }
