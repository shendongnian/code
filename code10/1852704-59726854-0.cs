<ActivityIndicator Color="Accent" IsVisible="{Binding IsBusy}" IsRunning="{Binding IsBusy}" />
BaseViewModel (Inherited by all ViewModels)
private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }
Get yourself a good MVVM framework (Prism) and put the network check in the OnNavigatedTo method for your start page.
 public override void OnNavigatedTo(INavigationParameters parameters)
 {
      IsBusy = true;
      await CheckNetwork();
      IsBusy = false;
 }
Now you can paste that same ActivityIndicator snippet into any page (XAML) that is bound to a ViewModel inheriting BaseViewModel and it will just work when you set IsBusy.
