    using System.Windows;
    namespace MyCompany.MyProject
    {
        public partial class App : Application
        {
            private void ApplicationStartup(object sender, StartupEventArgs e)
            {
                // Todo: Somehow load initial data...
                var viewModel = new ViewModel.EntryViewModel(
                    "some name", "some email", "some phone number",
                    "some relationship"
                    );
                var view = new View.EntryView()
                {
                    DataContext = viewModel
                };
                view.Show();
            }
        }
    }
