        private RelayCommand _InsertItemCommand;
        /// <summary>
        /// 
        /// </summary>
        public RelayCommand InsertItemCommand
        {
            get
            {
                if (_InsertItemCommand == null)
                {
                    _InsertItemCommand = new RelayCommand(
                        () =>
                        {
                            AppWindow appWin = new AppWindow();
                            appWin.DataContext = new ItemViewModel();
                            appWin.Show();
                            // OR
                            // AppWindow appWin = new AppWindow();
                            // ItemViewModel newApp = new ItemViewModel();
                            // appWin.DataContext = newApp;
                            // newApp.IsOpened = true;
                        },
                        () =>
                        {
                            return true;
                        });
                }
                return _InsertItemCommand;
            }
        }
