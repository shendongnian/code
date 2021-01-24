    public partial class App : Application
    {
            public App():base()
            {
                    Application.Current.DispatcherUnhandledException += new
                       System.Windows.Threading.DispatcherUnhandledExceptionEventHandler(
                          AppDispatcherUnhandledException);
                    throw new InvalidOperationException("exception");
            }
    
    void AppDispatcherUnhandledException(object sender,
               System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
            {
                //do whatever you need to do with the exception
                //e.Exception
                  MessageBox.Show(e.Exception.Message);
                    e.Handled = true;
                
            }
    }
