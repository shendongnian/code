        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            //  Save the settings before exit
            Properties.Settings.Default.Save();
        }
