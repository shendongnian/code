    public partial class App : Application
    {
        [STAThread]
        public static void Main()
        {
            YourNamespace.App app = new YourNamespace.App();
            app.InitializeComponent();
            app.Run();
        }
    }
