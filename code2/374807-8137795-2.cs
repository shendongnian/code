    public App : Application
    {
            protected override void OnStartup(StartupEventArgs e)
            {
                base.OnStartup(e);
                var splash = new Splash();
                var main = new Main();
    
                splash.SplashViewFinished += (s, data) => {
                    main.Data = data;
                  
                    //code to show main..
                };
    
                //code to show splash...
            }
    }
    
    public class Splash : Window
    {
        public event EventHandler<SplashDataArgs> SplashViewFinished;
    }
    
    public class SplashDataArgs: EventArgs
    {
        
    }
