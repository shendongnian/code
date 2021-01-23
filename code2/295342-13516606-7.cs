    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Show first form and start the message loop
            (new Form1()).Show();
            Application.Run(); // needed, otherwise app closes immediately
        }
    }
