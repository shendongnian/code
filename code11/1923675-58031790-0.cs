    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Child1ViewModel = new Child1ViewModel(this); // inject parent view model to child view model
            //Child2ViewModel = new Child2ViewModel(this);
        }
        public event SaveAllEventHandler SaveAll; // Child view models can subscribe to this event
        // ...
    }
    
    public class Child1ViewModel : ViewModelBase
    {
        public Child1ViewModel(MainViewModel parentViewModel)
        {
            parentViewModel.SaveAll += OnSaveAll;
        }
        private void OnSaveAll(object sender, SaveAllEventArgs e)
        {
            //
        }
    }
