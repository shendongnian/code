public partial class MainWindow : Window
{
   private MainWindowViewmodel _viewmodel;
   public MainWindow(Connection connection)
   {
      InitializeComponent();
      _viewmodel = (MainWindowViewmodel)DataContext;
      Loaded += MainWindowLoaded;
   }
   private void MainWindowLoaded(object sender, RoutedEventArgs e)
   {
      _viewmodel.UpdateJobs();
   }
}
