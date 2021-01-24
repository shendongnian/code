c#
static class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Form1 form1 = new Form1();
        Application.Run(form1);
    }
}
`Application.Run(form1);` is basically saying "this instance of Form1 is my application, keep running until this form closes."
When you invoke `this.Close();` you are closing your Form1 instance which is basically closing your whole application down.
