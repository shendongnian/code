    class StartUp
    {
        [STAThread]
        public static void Main()
        {
        try
        {
            Process[] processes = new Process[6];
            App app = new App();
            app.InitializeComponent();
            app.Run();
            Process.GetCurrentProcess().Kill(); //Must add this line after app.Run!!!
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
        }
