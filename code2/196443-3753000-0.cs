        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 f = new Form1();
            f.StartPosition = FormStartPosition.Manual;
            f.Location = Screen.PrimaryScreen.Bounds.Location;
            Application.Run(f);
        }
