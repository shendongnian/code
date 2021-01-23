    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        OpenFileDialog o = new OpenFileDialog();
        if (DialogResult.OK == o.ShowDialog())
        {
            Application.Run(new Form1(o.FileName));
        }
        else
        {
            Application.Exit();
        }
    }
