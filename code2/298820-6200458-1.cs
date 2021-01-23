    class ViewModel
    {
    
        private EventHandler _saveButtonClickedHandler;
        // ...
    
        public ViewModel()
        {
            _saveButtonClickedHandler = (s, e) => SaveData();
            this.globalEvents.OnSaveButtonClicked += _saveButtonClickedHandler;
            // ...
        }
    
        public void Dispose()
        {
            this.globalEvents.OnSaveButtonClicked -= _saveButtonClickedHandler;
            // ...
        }
        // ...
    }
