c#
partial class SplashScreen : Form
{
    public static SplashScreen Instance { get; } = new SplashScreen();
    private readonly RichTextBox richTextBox1 = new RichTextBox();
    public SplashScreen()
    {
        InitializeComponent();
        // 
        // richTextBox1
        // 
        richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        richTextBox1.Location = new Point(13, 13);
        richTextBox1.Name = "richTextBox1";
        richTextBox1.Size = new Size(775, 425);
        richTextBox1.TabIndex = 0;
        richTextBox1.Text = "";
        Controls.Add(richTextBox1);
    }
    public void PrintToSplashWindow(PrintToSplashMessage theMessage)
    {
        print_to_window(theMessage.Message, theMessage.MessageColor, theMessage.OnNewLine);
    }
    public void print_to_window(string strShortMsg, Color lngColor, bool blnOnNewLine)
    {
        string strNewLine = String.Empty;
        if (blnOnNewLine)
        {
            if (richTextBox1.Text.Length > 0)
            {
                strNewLine = Environment.NewLine;
            }
            else
            {
                strNewLine = "";
            }
        }
        else
        {
            strNewLine = "";
        }
        richTextBox1.SelectionStart = richTextBox1.Text.Length;
        richTextBox1.SelectionColor = lngColor;
        richTextBox1.SelectedText = strNewLine + strShortMsg;
        richTextBox1.SelectionStart = richTextBox1.Text.Length;
        richTextBox1.ScrollToCaret();
    }
}
It's not clear to me why you have two different classes, both of which seem to be set up as the entry point for the program. I consolidated those into a single class:
c#
static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        loadObjects();
        Application.Run(new Form1());
    }
    public static void loadObjects()
    {
        SplashScreen.Instance.Shown += async (sender, e) =>
        {
            Progress<PrintToSplashMessage> messageToWindow = new Progress<PrintToSplashMessage>();
            messageToWindow.ProgressChanged += reportProgress;
            SplashScreen.Instance.print_to_window("Starting Services", Color.Black, true);
            Task<bool> load1Task = load1(messageToWindow);
            Task<bool> load2Task = load2(messageToWindow);
            await Task.WhenAll(load1Task, load2Task);
            SplashScreen.Instance.Close();
        };
        SplashScreen.Instance.ShowDialog();
    }
    private static async Task<bool> load2(IProgress<PrintToSplashMessage> progress)
    {
        return await Task.Run(() =>
        {
            PrintToSplashMessage theMessage = new PrintToSplashMessage("Load2, please wait...", Color.Black, true, false);
            progress.Report(theMessage);
            for (int i = 0; i < 10; ++i)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1)); // CPU-bound work
                theMessage.Message = $"Load2, i = {i}";
                progress.Report(theMessage);
            }
            return true;
        });
    }
    private static async Task<bool> load1(IProgress<PrintToSplashMessage> progress)
    {
        return await Task.Run(() =>
        {
            PrintToSplashMessage theMessage = new PrintToSplashMessage("Load1, please wait...", Color.Black, true, false);
            progress.Report(theMessage);
            for (int i = 0; i < 10; ++i)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1)); // CPU-bound work
                theMessage.Message = $"Load1, i = {i}";
                progress.Report(theMessage);
            }
            return true;
        });
    }
    private static void reportProgress(object sender, PrintToSplashMessage e)
    {
        SplashScreen.Instance.PrintToSplashWindow(e);
    }
}
  [1]: https://stackoverflow.com/help/mcve
