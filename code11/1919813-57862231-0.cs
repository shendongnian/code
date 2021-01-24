c#
static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MyForm());
    }
}
class MyForm : Form
{
    public MyForm()
    {
        DoubleBuffered = true;
        Load += new System.EventHandler(this.Form_Load);
    }
    void Form_Load(object sender, EventArgs e)
    {
        // TODO
    }
}
