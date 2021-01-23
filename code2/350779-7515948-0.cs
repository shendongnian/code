    private ObservableCollection<WarrantNameDataView> warrantNameResult;
        public ObservableCollection<WarrantNameDataView> WarrantNameResult
        {
            get { return warrantNameResult; }
            set
            {
                warrantNameResult = value;
                NotifyPropertyChanged(vm => vm.WarrantNameResult);
            }
        }
