    public class Program
    {
      // Entry point method
      [STAThread]
      public static void Main()
      {
         var thread = new System.Threading.Thread(CreateApp);
         thread.SetApartmentState(System.Threading.ApartmentState.STA);
         thread.Start();
         // This is kinda shoddy, but the thread needs some time 
         // before we can invoke anything on the dispatcher
         System.Threading.Thread.Sleep(100);
         // In order to get input from the user, display a
         // dialog and return the result on the dispatcher
         var result = (int)Application.Current.Dispatcher.Invoke(new Func<int>(() =>
            {
               var win = new MainWindow();
               win.ShowDialog();
               return 10;
            }), null);
         // Show something to the user without waiting for a result
         Application.Current.Dispatcher.Invoke(new Action(() =>
         {
            var win = new MainWindow();
            win.ShowDialog();
         }), null);
     
         System.Console.WriteLine("result" + result);
         System.Console.ReadLine();
         // This doesn't really seem necessary 
         Application.Current.Dispatcher.InvokeShutdown();
      }
      private static void CreateApp()
      {
         App app = new App();
         app.ShutdownMode = ShutdownMode.OnExplicitShutdown;
         app.Run();
      }
    }
