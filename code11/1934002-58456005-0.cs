public static MainWindow Instance;
public MainWindow()
{
    InitializeComponent();
    Instance = this;
}
Change your `static` "outside" method to:
public static void LogConsole(string message, string type = "Default")
{
    Application.Current.Dispatcher.Invoke(new Action(() =>
    {
        if (MainWindow.Instance != null)
        {
            (MainWindow.Instance.LogConsole(message, type)
        }
        else
        {
            //Do something if MainWindow isn't loaded yet
        }
    }));
}
And change your "inside" method to:
public void LogConsole(string message, string type = "Default")
{            
    ConsoleLogBox.Text += $"{Environment.NewLine}[{DateTime.Now.ToString("h:mm:ss tt")}] {message}";
    ConsoleLogBox.ScrollToEnd();
}
Notice I've removed the creation of a new thread, because all you were doing was creating a new thread to immediately call the UI thread again, which is pointless.  
For the `static` version, unless you plan on calling it from another thread, you can remove `Dispatcher.Invoke`. I left it in just in case.
