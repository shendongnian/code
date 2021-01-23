    static void Main()
    {
        Application.EnableVisualStyles();
        Application.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
        Application.SetCompatibleTextRenderingDefault(false);
     
            System.ComponentModel.BackgroundWorker bw = new System.ComponentModel.BackgroundWorker();
            bw.DoWork += new System.ComponentModel.DoWorkEventHandler(bw_DoWork);
            bw.WorkerSupportsCancellation = true;
            MainForm = new MainForm(); // creating main form
