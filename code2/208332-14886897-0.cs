    /// <summary>
        /// This is delay loaded to allow us to capture the class type of the inherited class on request
        /// </summary>
        private ILog log = null;
        protected ILog Log
        {
            get
            {
                if (log == null)
                {
                    log = LogManager.GetLogger(this.GetType());
                }
                return log;
            }
        }
