    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var sender = new SendDataForm();
            sender.Show();
            Application.Run(new ReceiveDataForm());
        }
    }
