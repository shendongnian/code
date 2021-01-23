        public ICommand CancelLoadingCommand
        {
            get
            {
                if (_cancelLoadingCommand== null)
                {
                    this._cancelLoadingCommand= new RelayCommand(
                        delegate
                        {
                            // Cancel the loading process.
                        },
                        delegate
                        {
                            return !this.IsLoaded;
                        }
                    );
                }
                return _cancelLoadingCommand;
            }
        }
