    public class PropertiesInterceptor
    {
        private readonly AnswerViewModel viewModel;
    
        private readonly List<string> propertiesToIntercept =
            new List<string> { "property1", "property2", "property3" };
    
        public PropertiesInterceptor(AnswerViewModel viewModel)
        {
            this.viewModel = viewModel;
            viewModel.PropertyChanged += OnPropertyChanged;
        }
    
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (propertiesToIntercept.Contains(args.PropertyName))
            {
                DoStuff();
            }
        }
    
        private void DoStuff()
        {
            // Do something with viewModel
        }
    }
