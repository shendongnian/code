    [RunInstaller(true)]
    public partial class ServiceWrapperInstaller  : Installer
    {
        private const string nameKey = "name";
        private const string displayNameKey = "displayname";
        private const string descriptionKey = "description";
        protected override void OnBeforeInstall(IDictionary savedState)
        {
            // Set installer parameters
            SetParameters();
            base.OnBeforeInstall(savedState);
        }
        private void SetParameters()
        {
            // Set service name
            _serviceInstaller.ServiceName = this.Context.Parameters[nameKey];
            // Set the display name (if provided)
            if (Context.Parameters.ContainsKey(displayNameKey))
            {
                _serviceInstaller.DisplayName = this.Context.Parameters[displayNameKey];
            }
            // Set the description (if provided)
            if (Context.Parameters.ContainsKey(descriptionKey))
            {
                _serviceInstaller.Description = this.Context.Parameters[descriptionKey];
            }
            _serviceInstaller.StartType = ServiceStartMode.Automatic;
            _serviceInstaller.DelayedAutoStart = true;
        }
    }
