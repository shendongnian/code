language c#
public partial class MainWindow : Window
{
    ParseLog logParser;
    public MainWindow()
    {
        InitializeComponent();
        logParser = new ParseLog();
    }
    protected override void OnClosed(EventArgs e)
    {
        logParser.Dispose();
        base.OnClosed(e);
    }
}
class ParseLog : IDisposable
{
    public string[] updatedFiles;
    readonly Timer stateTimer;
    public ParseLog()
    {
        AutoResetEvent autoEvent = new AutoResetEvent(false);
        Console.WriteLine("{0:h:mm:ss.fff} Creating timer.\n",
                            DateTime.Now);
        // Create a timer that invokes CheckFile every 3 seconds
        stateTimer = new Timer(CheckFile, autoEvent, 0, 3000);
    }
    public void CheckFile(Object stateInfo)
    {
        AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
        Console.WriteLine("{0} Checking files.",
            DateTime.Now.ToString("h:mm:ss.fff"));
    }
    public void Dispose()
    {
        stateTimer.Dispose();
    }
}
