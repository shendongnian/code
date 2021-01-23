    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //See if exactly one command line argument was passed
            if (e.Args.Length == 1)
            {
                //See if the argument is one of our 'known' values
                switch (e.Args[0])
                {
                    case "launchApp2":
                        secondProject.WPFWindow win2 = new secondProject.WPFWindow();
                        win2.Show();
                        break;
                    case "launchApp3":
                        thirdProject.OtherWPFWindow win3 = new thirdProject.OtherWPFWindow();
                        win3.Show();
                        break;
                }
            }
            //Probably want to call the base class always?
            base.OnStartup(e);
        }
    }
