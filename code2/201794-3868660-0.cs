    [STAThread]
    static void Main()                  // args are OK here, of course
    {
        bool ok;
        using(var mutex = new System.Threading.Mutex(true, "YourNameHere", out ok))
        {
            if (!ok)
            {
                MessageBox.Show("Another instance is already running.");
                return;
            }
            Application.Run(new Form1());
        }
    }
