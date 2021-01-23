    static class Program
    {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
    Application.SetCompatibleTextRenderingDefault(false);
    Application.EnableVisualStyles();
    Thread thread = new Thread(() =>
    {
    Form1 form1 = new Form1();
    form1.Visible = false;
    form1.ShowInTaskbar = false;
    Application.Run(form1);
    });
    thread.SetApartmentState(ApartmentState.STA);
    thread.Start();
    }
    }
