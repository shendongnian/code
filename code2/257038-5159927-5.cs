    public class MainViewModel
    {
         public ViewModel1 ViewModel1 { get; private set; }
         public ViewModel2 ViewModel2 { get; private set; }
         public ViewModel3 ViewModel3 { get; private set; }
         // this will be handled by IoC container
         public MainViewModel(ViewModel1 viewModel1, ViewModel2 viewModel2, ViewModel3 viewModel3)
        {
            ViewModel1 = viewModel1;
            ViewModel2 = viewModel2;
            ViewModel3 = viewModel3;
        }
