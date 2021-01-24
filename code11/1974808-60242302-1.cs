    using System;
    using System.IO;
    using System.Threading;
    using System.Windows;
    using System.Xml;
    
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void ShowWindow(string Xaml)
            {
                var s = XmlReader.Create(new StringReader(Xaml));
                var win = (Window)System.Windows.Markup.XamlReader.Load(s);
                win.ShowDialog();
            }
            static void Main(string[] args)
            {
    
               Application app = null;
               var UIThread = new Thread(() =>
               {
                   app = new Application();
                   app.ShutdownMode = ShutdownMode.OnExplicitShutdown;
                   app.Run();
               });
    
                UIThread.SetApartmentState(ApartmentState.STA);
                UIThread.Start();
    
                while (app == null )
                    Thread.Sleep(100);
    
                app.Dispatcher.Invoke(() => Console.WriteLine("Started"));
    
    
                var xaml = @"
            <Window
                xmlns = ""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
                xmlns:x = ""http://schemas.microsoft.com/winfx/2006/xaml""
                Title = ""IronPython MVVM Demo2""
                Width = ""450""
                SizeToContent = ""Height"">
                <Grid Margin = ""15"" x:Name = ""grid1"">
                    <StackPanel Margin = ""5"">
                        <Button Margin = ""5""> One </Button>
                        <Button Margin = ""5""> Two </Button>
                        <Button Margin = ""5""> Three </Button>
                    </StackPanel>
                </Grid>
            </Window>";        
    
                for (int i = 0; i < 3; i++)
                {
                    
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        ShowWindow(xaml);
                    });
                }
    
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Application.Current.Shutdown();
                });
    
            }
        }
    }
