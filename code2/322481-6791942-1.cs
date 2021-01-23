    namespace Service
    {
        public partial class RequisitionService : ServiceBase
        {
    
            #region Members
    
            private ProcessingManager m_ProcessingManager = null;
    
            #endregion Members
    
    
            #region Constructor
    
            /// <summary>
            /// Constructor
            /// </summary>
            public RequisitionService()
            {
                InitializeComponent();
    
                try
                {
                    //Add a handler for unhandled Exceptions
                    AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
    
                    //Instantiate the processing manager
                    m_ProcessingManager = new ProcessingManager();
                }
                catch (Exception ex)
                {
                    ErrorHandler.LogError(ex);
                }
            }
    
            #endregion Constructor
    
    
            #region Events
    
            /// <summary>
            /// Handles an Unhandled Exception
            /// </summary>
            /// <param name="sender">object</param>
            /// <param name="e">args</param>
            void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
            {
                try
                {
                    ErrorHandler.LogError(new Exception("Unhandled Exception Encountered", e.ExceptionObject as Exception));
                }
                catch (Exception ex)
                {
                    ErrorHandler.LogError(ex);
                }
            }
    
            /// <summary>
            /// Starts the processing
            /// </summary>
            /// <param name="args">Parameters</param>
            protected override void OnStart(string[] args)
            {
                try
                {
                    ErrorHandler.LogEntry("Starting Processing", EventLogEntryType.Information);
    
                    //Start the Processing
                    m_ProcessingManager.Start();
                }
                catch (Exception ex)
                {
                    ErrorHandler.LogError(ex);
                }
            }
    
            /// <summary>
            /// Service Stopped
            /// </summary>
            protected override void OnStop()
            {
                try
                {
                    ErrorHandler.LogEntry("Stopping Processing", EventLogEntryType.Information);
    
                    //Stop Processing
                    m_ProcessingManager.Stop();
                }
                catch (Exception ex)
                {
                    ErrorHandler.LogError(ex);
                }
            }
    
            #endregion Events
    
        }
    }
