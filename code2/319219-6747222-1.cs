    [AddInBase]
    public class AddInView : UserControl
    {
        //Necessary constructor to handle the exception.
        //Normal constructor is not called when an error occurs at startup!!!
        static AddInView()
        {
            AppDomain.CurrentDomain.DomainUnload += CurrentDomain_DomainUnload;
        }
        //Normal constructor
        public AddInView()
        {
            //Do other things...
            //e.g. Dispatcher.UnhandledException += Dispatcher_UnhandledException;
        }
    
        static void CurrentDomain_DomainUnload(object sender, EventArgs e)
        {
            //To cleanup and stuff
        }
    }
