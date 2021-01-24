    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (var form = new Form1())
            {
                form.SomeEvent += onSomeEvent;
                Application.Run(form);
            }
        }
        static void onSomeEvent(object sender, MyEventArgs e)
        {
            Task.Run(() => handleEvent(e));
        }
        static void handleEvent(MyEventArgs e)
        {
            Thread.Sleep(4000);
            e.Finished.Release();
        }
    }
