    public class PropertiesInterceptor
    {
        private readonly AnswerViewModel viewModel;
    
        public PropertiesInterceptor(AnswerViewModel viewModel)
        {
            this.viewModel = viewModel;
            viewModel.PropertyChanged += (sender, args) => DoStuff();
        }
    
        private void DoStuff()
        {
            // Do something with viewModel
        }
    }
