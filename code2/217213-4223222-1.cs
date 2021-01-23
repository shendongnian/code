    public class WpfApp : System.Windows.Application
    {
    protected override void OnStartup(System.Windows.StartupEventArgs e)
    {
    base.OnStartup(e);
    WpfApp.current = this;
    // Load the main window.
    DocumentList list = new DocumentList();
    this.MainWindow = list;
    list.Show();
    // Load the document that was specified as an argument.
    if (e.Args.Length > 0) ShowDocument(e.Args[0]);
    }
    public void ShowDocument(string filename)
    {
    try
    {
    Document doc = new Document();
    doc.LoadFile(filename);
    doc.Owner = this.MainWindow;
    doc.Show();
    // If the application is already loaded, it may not be visible.
    // This attempts to give focus to the new window.
    doc.Activate();
    }
    catch
    {
    MessageBox.Show("Could not load document.");
    }
    }
    }
