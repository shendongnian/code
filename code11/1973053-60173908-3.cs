    class Program
    {
        static void Main(string[] args)
        {
            Thread t = CreateThread();
            t.Start();
            bool quit = false;
            while (!quit)
            {
                switch(Console.ReadKey().Key)
                {
                    case ConsoleKey.Escape:
                        Application.Current.Dispatcher.Invoke(() => Application.Current.Shutdown());
                        quit = true;
                        break;
                    case ConsoleKey.W:
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            var w = new Window() { Width = 500, Height = 500, Title = "WPF Window" };
                            w.Show();
                        });
                        break;
                    case ConsoleKey.D:
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            var d = new Window() { Width = 500, Height = 500, Title = "WPF Dialog" };
                            d.ShowDialog();
                        });
                        break;
                    case ConsoleKey.Spacebar:
                        //// Nope!
                        //Application.Current.Dispatcher.Invoke(() => Application.Current.Shutdown());
                        //t = CreateThread();
                        //t.Start();
                        break;
                }
            };
        }
        static Thread CreateThread()
        {
            var t = new Thread(() =>
            {
                if (System.Windows.Application.Current == null)
                {
                    new System.Windows.Application();
                    Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
                }
                Application.Current.Run();
            });
            t.SetApartmentState(ApartmentState.STA);
            return t;
        }
    }
