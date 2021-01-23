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
                            ItemWindow itemWin = new ItemWindow();
                            itemWin.DataContext = new ItemViewModel();
                            itemWin.Show();
                            // OR
                            // ItemWindow itemWin = new ItemWindow();
                            // ItemViewModel newItem = new ItemViewModel();
                            // itemWin.DataContext = newItem;
                            // newItem.IsOpened = true;
                        },
                        () =>
                        {
                            return true;
                        });
                }
                return _InsertItemCommand;
            }
        }
