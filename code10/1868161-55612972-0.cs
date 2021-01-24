        private DelegateCommand _saveCommand;
        public DelegateCommand SaveCommand =>
            _saveCommand ?? (_saveCommand = new DelegateCommand(ExecuteSaveCommand, CanExecuteSaveCommand));
        void ExecuteSaveCommand()
        {
            // Save logic goes here
        }
        private bool CanExecuteSaveCommand()
        {
            var isDirty = CurrentRecord.GetIsDirty();
            return isDirty;
        }
