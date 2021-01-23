    public class PoundViewModel
    {
        // No WPF application is complete without at least 1 ObservableCollection
        public ObservableCollection<DogViewModel> Dogs
        {
            get;
            private set;
        }
        // Commands play a large role in WPF as a means of 
        // transmitting "actions" from UI elements
        public ICommand AddDogCommand
        {
            get;
            private set;
        }
        public PoundViewModel()
        {
            this.Dogs = new ObservableCollection<DogViewModel>();
            // The Command takes a string parameter which will be provided
            // by the UI. The first method is what happens when the command
            // is executed. The second method is what is queried to find out
            // if the command should be executed
            this.AddDogCommand = new DelegateCommand<string>(
                name => this.Dogs.Add(new DogViewModel { Name = name }),
                name => !String.IsNullOrWhitespace(name)
            );
        }
    }
