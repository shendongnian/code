        private RelayCommand<anyobject> _AddCmd;
        public ICommand AddPoint
        {
            get
            {
                return _AddCmd ??
                    (
                    _AddCmd = new RelayCommand
                        (
                            (obj) =>
                            {
                                ViewModelWF.ZeroPoints.Add(new WM.Point(0, 0));
                            }
                        )
                    );
            }
        }
        private RelayCommand _DeleteCmd;
        public ICommand DeletePoint
        {
            get
            {
                return _DeleteCmd ??
                    (
                    _DeleteCmd = new RelayCommand
                        (
                            () =>
                            {
                                int idx = wpfZeroPoints.SelectedIndex;
                            },
                            () =>
                            {
                                return wpfZeroPoints.SelectedIndex <= 0;
                            }
                        )
                    );
            }
        }
