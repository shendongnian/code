    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            ILogService logService = ...;
            App app = new App(logService);
            app.InitializeComponent();
            app.Run();
        }
    }
