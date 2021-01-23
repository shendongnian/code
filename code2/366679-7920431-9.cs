        protected override void OnCommitted(System.Collections.IDictionary savedState)
        {
            base.OnCommitted(savedState);
            new ServiceController(serviceInstaller1.ServiceName).Start();
        }
