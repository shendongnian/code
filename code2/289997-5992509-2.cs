        public bool VibrationOn { get; set; }
        private void Application_Launching(object sender, LaunchingEventArgs e)
        {
            LoadSettings();
        }
        private void Application_Activated(object sender, ActivatedEventArgs e)
        {
            LoadSettings();
        }
        private void Application_Deactivated(object sender, DeactivatedEventArgs e)
        {
            SaveSettings();
        }
        private void Application_Closing(object sender, ClosingEventArgs e)
        {
            SaveSettings();
        }
        private void LoadSettings()
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            bool vo;
            if (settings.TryGetValue<bool>("VibrationOn", out vo))
                VibrationOn = vo;
            else
                VibrationOn = true;
        }
        private void SaveSettings()
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            settings["VibrationOn"] = VibrationOn;
        }
