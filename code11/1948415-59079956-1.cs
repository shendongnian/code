     private RelayCommand _outerClickCommand;
        public RelayCommand OuterClickCommand
        {
            get
            {
                return _outerClickCommand
                    ?? (_outerClickCommand = new RelayCommand(
                    () => { MessageBox.Show("OuterClickCommand"); }));
            }
        }
        private RelayCommand _innerClickCommand;
        public RelayCommand InnerClickCommand
        {
            get
            {
                return _innerClickCommand
                    ?? (_innerClickCommand = new RelayCommand(
                    () => { MessageBox.Show("InnerClickCommand"); }));
            }
        }
