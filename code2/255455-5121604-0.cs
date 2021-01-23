static class Program
{
    internal static Form1 MyForm1;
    internal static Form2 MyForm2;
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        //Application.Run(new Form1());
        // Initialize Form1
        MyForm1 = new Form1();
        MyForm1.FormClosing += new FormClosingEventHandler(MyForm1_FormClosing);
        // You may want to initialize Form2 on-demand instead of up front like here.
        MyForm2 = new Form1();
        MyForm2.FormClosing += new FormClosingEventHandler(MyForm2_FormClosing);
        // Show Form1 first
        MyForm1.Show();
        // Now we need to occupy the thread so it won't exit the app. This is normally the job of Application.Run.
        // An alternative to this is to have a third form you pass on control to.
        while (true)
        {
            Application.DoEvents();
            System.Threading.Thread.Sleep(10);
        }
    }
    static void MyForm1_FormClosing(object sender, FormClosingEventArgs e)
    {
        // Do something, for example show Form2
        MyForm2.Show();
        // EXAMPLE: We only want to hide it?
        e.Cancel = true;
        MyForm1.Visible = false;
    }
    static void MyForm2_FormClosing(object sender, FormClosingEventArgs e)
    {
        // Do something, for example show Form1
        MyForm1.Show();
        // EXAMPLE: We only want to hide it?
        e.Cancel = true;
        MyForm2.Visible = false;
    }
}
