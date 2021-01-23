    using System;
    using System.Security.Cryptography;
    using System.Threading;
    class BeatBox : IDisposable
    {
        private RandomNumberGenerator RNG;
        private DateTime dtStarted;
        private TimeSpan TimeElapsed { get { return DateTime.Now - dtStarted; } }
        private TimeSpan  Duration;
        private TimeSpan  BeatInterval;
        private uint      MinRandomInterval;
        private uint      MaxRandomInterval;
        private uint      RandomIntervalDomain;
        private Timer     RegularIntervalTimer;
        private Timer     RandomIntervalTimer;
        public delegate void TickHandler( object sender , bool isRandom );
        public event TickHandler TickEvent;
        private EventWaitHandle CompletionEventWaitHandle;
        public BeatBox( TimeSpan duration , TimeSpan beatInterval , uint minRandomInterval , uint maxRandomInterval )
        {
            this.RNG = RandomNumberGenerator.Create();
            this.Duration             = duration          ;
            this.BeatInterval         = beatInterval      ;
            this.MinRandomInterval    = minRandomInterval ;
            this.MaxRandomInterval    = maxRandomInterval ;
            this.RandomIntervalDomain = ( maxRandomInterval - minRandomInterval ) + 1 ;
            this.dtStarted            = DateTime.MinValue ;
            this.RegularIntervalTimer = null ;
            this.RandomIntervalTimer  = null ;
            return;
        }
        private long NextRandomInterval()
        {
            byte[] entropy = new byte[sizeof(long)] ;
            RNG.GetBytes( entropy );
            long randomValue    = BitConverter.ToInt64( entropy , 0 ) & long.MaxValue; // ensure that its positive
            long randomoffset   = ( randomValue % this.RandomIntervalDomain );
            long randomInterval = this.MinRandomInterval + randomoffset;
            return randomInterval;
        }
        public EventWaitHandle Start()
        {
            long randomInterval = NextRandomInterval();
            this.CompletionEventWaitHandle = new ManualResetEvent( false );
            this.RegularIntervalTimer = new Timer( RegularBeat , null , BeatInterval , BeatInterval );
            this.RandomIntervalTimer = new Timer( RandomBeat , null , randomInterval , Timeout.Infinite );
            return this.CompletionEventWaitHandle;
        }
        private void RegularBeat( object timer )
        {
            if ( this.TimeElapsed >= this.Duration )
            {
                MarkComplete();
            }
            else
            {
                this.TickEvent.Invoke( this , false );
            }
            return;
        }
        private void RandomBeat( object timer )
        {
            if ( this.TimeElapsed >= this.Duration )
            {
                MarkComplete();
            }
            else
            {
                this.TickEvent.Invoke( this , true );
                long nextInterval = NextRandomInterval();
                this.RandomIntervalTimer.Change( nextInterval , Timeout.Infinite );
            }
            return;
        }
        private void MarkComplete()
        {
            lock ( this.CompletionEventWaitHandle )
            {
                bool signaled = this.CompletionEventWaitHandle.WaitOne( 0 );
                if ( !signaled )
                {
                    this.RegularIntervalTimer.Change( Timeout.Infinite , Timeout.Infinite );
                    this.RandomIntervalTimer.Change( Timeout.Infinite , Timeout.Infinite );
                    this.CompletionEventWaitHandle.Set();
                }
            }
            return;
        }
        public void Dispose()
        {
            if ( RegularIntervalTimer != null )
            {
                WaitHandle handle = new ManualResetEvent( false );
                RegularIntervalTimer.Dispose( handle );
                handle.WaitOne();
            }
            if ( RandomIntervalTimer != null )
            {
                WaitHandle handle = new ManualResetEvent( false );
                RegularIntervalTimer.Dispose( handle );
                handle.WaitOne();
            }
            return;
        }
    }
    class Program
    {
        static void Main( string[] args )
        {
            TimeSpan duration          = new TimeSpan( 0 , 5 , 0 ); // run for 5 minutes total
            TimeSpan beatInterval      = new TimeSpan( 0 , 0 , 1 ); // regular beats every 1 second
            uint     minRandomInterval = 5; // minimum random interval is 5ms
            uint     maxRandomInterval = 30; // maximum random interval is 30ms
            using ( BeatBox beatBox = new BeatBox( duration , beatInterval , minRandomInterval , maxRandomInterval ) )
            {
                beatBox.TickEvent += TickHandler;
                EventWaitHandle completionHandle = beatBox.Start();
                completionHandle.WaitOne();
            }
            return;
        }
        static void TickHandler( object sender , bool isRandom )
        {
            Console.WriteLine( isRandom ? "Random Beep!" : "Beep!" );
            return;
        }
    }
