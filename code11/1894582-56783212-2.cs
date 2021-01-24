    public class StatsViewModel : ViewModelBase
    {
        public StatsViewModel()
        {
        }
        private ICommand _LoadedCommand;
        public ICommand LoadedCommand => _LoadedCommand ?? (_LoadedCommand = new RelayCommand(LoaedAsync));
        private async void LoaedAsync()
        {
            var selectedObject = ViewModelLocator.Current.MainViewModel.SelectedStats;
            //TODO:...
            await Task.CompletedTask;
        }
    }
