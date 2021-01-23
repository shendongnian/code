    class Program : IDisposable
    {
        class RestartException : Exception
        {
            public RestartException() : base()
            {
            }
            public RestartException( string message ) : base(message)
            {
            }
            public RestartException( string message , Exception innerException) : base( message , innerException )
            {
            }
            protected RestartException( SerializationInfo info , StreamingContext context ) : base( info , context )
            {
            }
        }
        static int Main( string[] argv )
        {
            int  rc                      ;
            bool restartExceptionThrown ;
            do
            {
                restartExceptionThrown = false ;
                try
                {
                    using ( Program appInstance = new Program( argv ) )
                    {
                        rc = appInstance.Execute() ;
                    }
                }
                catch ( RestartException )
                {
                    restartExceptionThrown = true ;
                }
            } while ( restartExceptionThrown ) ;
            return rc ;
        }
        public Program( string[] argv )
        {
            // initialization logic here
        }
        public int Execute()
        {
            // core of your program here
            DoSomething() ;
            if ( restartNeeded )
            {
                throw new RestartException() ;
            }
            DoSomethingMore() ;
            return applicationStatus ;
        }
        public void Dispose()
        {
            // dispose of any resources used by this instance
        }
    }
