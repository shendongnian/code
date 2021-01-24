Task.Run( () => 
{
    InitFunction1("arguments");
    InitFunction2("arguments");
});
Or using other task/async tools for loading them in parallel, or in an otherwise non-blocking fashion.
Using the [WPF Tutorial][1] as a reference point. You might put it in the main window constructor, or otherwise override and create your own version of the InitializeComponent method.
namespace ExpenseIt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        public MainWindow()
        {
            YourCustomInitializationFunction(); // you could make this run async if you were feeling like it!
            InitializeComponent();
        }
    }
}
  [1]: https://docs.microsoft.com/en-us/dotnet/framework/wpf/getting-started/walkthrough-my-first-wpf-desktop-application
