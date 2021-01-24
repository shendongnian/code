    public partial class App : Application
        {
            protected override void OnStartup(StartupEventArgs e)
            {
                base.OnStartup(e);
                var mainWindow = new Window();
                var viewModel = new ViewModel();
                mainWindow.DataContext = viewModel;
                mainWindow.Show();
                viewModel.GetCourseIdFromDB();
            }
        }
    }
