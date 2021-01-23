    private DelegateCommand UpdateData1Command { get; set; }
        public MyViewModel()
        {
            this.UpdateData1Command = new DelegateCommand(_ => this.GetData1(), _ => this.IsGraph1Visible);
        }
        private bool isGraph1Visible;
        public bool IsGraph1Visible
        {
            get { return isGraph1Visible; }
            set
            {
                isGraph1Visible = value;
                OnPropertyChanged("IsGraph1Visible");
                if(UpdateData1Command.CanExecute(null))
                    UpdateData1Command.Execute(null);
            }
        }
        private void RunQueries()
        {
            if (UpdateData1Command.CanExecute(null))
                UpdateData1Command.Execute(null);
        }
        private void GetData1()
        {
            // call wcf service to get the data
        }
