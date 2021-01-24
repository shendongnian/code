       private AdLogEntry selectedAd;
       public AdLogEntry SelectedAd { get => selectedAd; set { selectedAd = value; OnPropertyChanged("SelectedAd"); } }
       public ICommand AdSelectionChangedCommand => new Command(AdSelectionChanged);
        private void AdSelectionChanged()
        {
            OnPropertyChanged("SelectedAd");
            Application.Current.MainPage.Navigation.PushModalAsync(new DetailPage(SelectedAd));
        }
