    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var view = new MainWindow();
            var vm = new EmployeesViewModel;
            view.DataContext = vm;
            view.Show();
        }
    }
