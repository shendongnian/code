     public partial class App : Application
        {
            private static SplashScreen _splashScreen;
    
            public App()
            {
                OpenSplashScreen();
                new Bootstrapper().Run(); 
            }
    
            private void OpenSplashScreen()
            {
                _splashScreen = new SplashScreen("SplashScreen/splash.jpg");
                _splashScreen.Show(false);
            }
    
            internal static void CloseSplashScreen(double time)
            {
                _splashScreen.Close(TimeSpan.FromSeconds(0));
                _splashScreen = null;
            }
        }
