    public class AppBootstrapper : Bootstrapper<MainViewModel>
    {
        protected override void OnExit(object sender, EventArgs e)
        {
            // Get the Main View Model
            MainViewModel mainViewModel = IoC.Get<MainViewModel>();
            if (mainViewModel.MyParam == 42)
            {
                //Do work
            }
            base.OnExit(sender, e);
        }
    }
