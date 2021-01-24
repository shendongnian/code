    class Program
    {
        const string AppUniqueGuid = "9da112cb-a929-4c50-be53-79f31b2135ca";
        [STAThread]
        static void Main(string[] args)
        {
            using (System.Threading.Mutex mutex
                = new System.Threading.Mutex(false, AppUniqueGuid))
            {
                if (mutex.WaitOne(0, false))
                {
                    App application = new App();
                    application.InitializeComponent();
                    application.Run();
                }
                else
                {
                    MessageBox.Show("Instance already running!");
                }
            }
        }
    }
