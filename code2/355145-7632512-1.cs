    public partial class App : Application
    {
    public App()
    {
        this.Dispatcher.UnhandledException += DispatcherUnhandledException;
        AppDomain.CurrentDomain.UnhandledException += CurrentDomainUnhandledException;
    }
    private void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        // log and close gracefully
    }
    private new void DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
    {
        e.Handled = true;
        // log and close gracefully
    }
    }
 
