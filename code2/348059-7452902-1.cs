    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //If a command line argument was passed and it was some special string,
            //   then we want to do the sleep.  Otherwise, we don't sleep and just
            //   continue on right away.
            if (e.Args.Length == 1 && e.Args[0] == "startup")
            {
                //Sleep for 60 seconds
                System.Threading.Thread.Sleep(60 * 1000);
            }
            //Continue on...
            base.OnStartup(e);
        }
    }
