csharp
[STAThread]
static void Main()
{
    Application.SetHighDpiMode(HighDpiMode.SystemAware);
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);
    Application.Run(new Form1());
}
As sander has said above, your code appears to be doing as you'd expect i.e. opening, sleeping for 5 seconds and ending. I imagine you've seen the same behaviour in a basic console app and got around it by using `Console.ReadLine()`... the same applies here in a sense.
