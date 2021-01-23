    using System;
    using System.Threading ;
    
    class AppCore : IDisposable
    {
        Timer    TimerInstance ;
        string[] Args          ;
        
        public AppCore( string[] args )
        {
            if ( args == null ) throw new ArgumentNullException("args") ;
            this.TimerInstance   = new Timer( Tick , null , new TimeSpan(0,0,30) , new TimeSpan(0,0,15) ) ;
            this.Args            = args ;
            this.Cancelled       = false ;
            this.Disposed        = false ;
            return ;
        }
        
        public int Run()
        {
            // do something useful
            return 0 ;
        }
        
        private bool Cancelled ;
        public void Cancel()
        {
            lock( TimerInstance )
            {
                Cancelled = true ;
                TimerInstance.Change( System.Threading.Timeout.Infinite , System.Threading.Timeout.Infinite ) ;
            }
            return ;
        }
        
        private void Tick( object state )
        {
            if ( !Cancelled )
            {
                // do something on each tick
            }
            return ;
        }
        
        private bool Disposed ;
        public void Dispose()
        {
            lock ( TimerInstance )
            {
                if ( !Disposed )
                {
                    using ( WaitHandle handle = new EventWaitHandle( false , EventResetMode.ManualReset ) )
                    {
                        TimerInstance.Dispose( handle ) ;
                        handle.WaitOne() ;
                    }
                    Disposed = true ;
                }
            }
            return ;
        }
        
    }
