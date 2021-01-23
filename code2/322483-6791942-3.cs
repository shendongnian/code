    namespace Service
    {
        public partial class Service : ServiceBase
        {
            #region Members
    
            private ProcessingManager m_ProcessingManager = null;
    
            #endregion Members
     
            #region Constructor
    
            /// <summary>
            /// Constructor
            /// </summary>
            public Service()
            {
                InitializeComponent();
    
                try
                {
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
            /// Starts the processing
            /// </summary>
            /// <param name="args">Parameters</param>
            protected override void OnStart(string[] args)
            {
                try
                {
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
