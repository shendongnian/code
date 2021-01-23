    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            this.ItemViewModel = new SampleViewModel { Title = "Some title", ViewType = ItemViewType.View1 };
            this.SwitchViewCommand = new RelayCommand(() =>
            {
                this.ItemViewModel.ViewType = this.ItemViewModel.ViewType == ItemViewType.View1
                                                ? ItemViewType.View2
                                                : ItemViewType.View1;
                //The magic senquence of actions which forces a contentcontrol to change the content template
                var copy = this.ItemViewModel;
                this.ItemViewModel = null;
                this.ItemViewModel = copy;
            });
        }
        public RelayCommand SwitchViewCommand { get; set; }
        private SampleViewModel itemViewModel;
        public SampleViewModel ItemViewModel
        {
            get { return itemViewModel; }
            set
            {
                itemViewModel = value;
                RaisePropertyChanged("ItemViewModel");
            }
        }
    }
