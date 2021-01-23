        private ICommand _newTestCommand, _newGroupCommand;        
        public ICommand NewTestCommand
        {
            get
            {
                if (this._newTestCommand == null)
                {
                    this._newTestCommand = new RelayCommand(parm => DoNewTest());
                } return this._newTestCommand;
            }
        }
        public ICommand NewGroupCommand
        {
            get
            {
                if (this._newGroupCommand == null)
                {
                    this._newGroupCommand = new RelayCommand(parm => DoNewGroup());
                } return this._newGroupCommand;
            }
        }
        private void DoNewTest()
        {
            // stuff
        }
        private void DoNewGroup()
        {
            // more stuff
        }
