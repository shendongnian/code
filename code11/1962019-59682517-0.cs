    public class Program
    {
        static void Main(string[] args)
        {
            App app = new App(args);
            app.InitializeComponent();
            app.Run();
        }
    }
    public partial class App : Application
    {
        public App(string[] args)
        {
            Demo("en-EN");
        }
        private static void Demo(string cultureCode)
        {
            WriteDate();
            SetCulture(cultureCode);
            for (int i = 0; i < 100; i++)
                Task.Run((Action)WriteDate);
        }
        private static void SetCulture(string code)
        {
            var ci = new CultureInfo(code);
            CultureInfo.DefaultThreadCurrentCulture = ci;
        }
        static void WriteDate()
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;
            var threadCulture = Thread.CurrentThread.CurrentCulture;
            System.Diagnostics.Debug.WriteLine($"Thread {threadId} with culture {threadCulture} => {DateTime.Now}");
        }
    }
