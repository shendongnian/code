    public partial class MainWindow : Window
        {
            SynchronizationContext UISyncContext;
            YourTaskOutPut Myresult;
            public MainWindow()
            {
                InitializeComponent();
            }
            public StartProcessingVGraphics()
            {
                //Let say this method is been called from UI thread. i.e on a button click
                //capture the current synchronization context
    
                UISyncContext=TaskScheduler.FromCurrentSynchronizationContext;
    
                //Start your VGraph processing using TPL in background and store result to Myresult (of type YourTaskOutPut)
                result= GetMeTaskResults();
              
            }
    
            public GetMeResultNow()
            {
                //Let's say this is is the method which user triggers at
                //some point in time ( with the assumption that we have Myresult in hand)
    
                if(UISyncContext!=null)
                    UISyncContext.Send(new SendOrPostCallback(delegate{ PutItInUI }),null);
    
                //Use Send method - to send your request synchronously
                //Use Post method- to send your request asynchronously
            }
            void PutItInUI()
            {
                //this method help you to put your result in UI/controls
            }
