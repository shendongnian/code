        /// <summary>
        /// Dispose Method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Deconstructor
        /// </summary>
        ~[PutYourClassHere]()
        {
            Dispose(false);
        }
        /// <summary>
        /// IDisposable Implementation
        /// </summary>
        /// <param name="disposing">Disposing Flag</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                //Free Managed Resources
            }
            //Free Native Resources 
        }
