        DispatcherTimer autosaveTimer = new DispatcherTimer(TimeSpan.FromSeconds(autosaveInterval), DispatcherPriority.Background, new EventHandler(DoAutoSave), Application.Current.Dispatcher);
        private void DoAutoSave(object sender, EventArgs e)
        {
            // Enter save logic here...
        }
