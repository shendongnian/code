        RelayCommand _DoSomethingCommand = null;
        public ICommand DoSomethingCommand
        {
            get
            {
                if (_DoSomethingCommand== null)
                {
                    _DoSomethingCommand= new RelayCommand(
                        param => DoSomething(),
                        param => DoSomethingCanExecute
                        );
                }
                return _DoSomethingCommand;
            }
        }
        public bool DoSomethingCanExecute
        {
            get
            {
                return CheckboxShouldBeEnabled();
            }
        }
        public void DoSomething()
        {
            //Checkbox has been clicked
        }
