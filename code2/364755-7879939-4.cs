    [Export(Typeof(MainViewModel))]
    public class MainViewModel : Screen,  IShell
    {
        [ImportingConstructor]
        public MainViewModel(YourFirstViewModel firstViewModel, YourSecondViewModel secondviewModel) // etc, for each child ViewModel
        {
        }
    }
