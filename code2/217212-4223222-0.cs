    public class SingleInstanceApplicationWrapper :
    Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase
    {
    public SingleInstanceApplicationWrapper()
    {
    // Enable single-instance mode.
    this.IsSingleInstance = true;
    }
    // Create the WPF application class.
    private WpfApp app;
    protected override bool OnStartup(
    Microsoft.VisualBasic.ApplicationServices.StartupEventArgs e)
    {
    app = new WpfApp();
    app.Run();
    return false;
    }
    // Direct multiple instances.
    protected override void OnStartupNextInstance(
    Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs e)
    {
    if (e.CommandLine.Count > 0)
    {
    app.ShowDocument(e.CommandLine[0]);
    }
    }
    }
