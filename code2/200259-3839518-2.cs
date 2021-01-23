    using System;
    using System.Timers;
    using System.Threading;
    public class Timer2
    {
        private static System.Timers.Timer aTimer;
        private static List<string> errors = new List<string>();
        private static readonly int interval = 300000;  // 5 minutes at present
        private static readonly int trigger = 10;       // send msg if > 10 errors
    
        // Message processing - error detection
        public static void processMessage(Message message)
        {
          // do the work here
          // then check error
          if (message.HasError)
          {
            // add error to pending list
            lock (errors)
            {
              string newErrorData = "got another one!";
              errors.Add(newErrorData);
              ++trigger;
            }
          }
        }
    
        public static void Main()
        {
            // Normally, the timer is declared at the class level,
            // so that it stays in scope as long as it is needed.
            // If the timer is declared in a long-running method,  
            // KeepAlive must be used to prevent the JIT compiler 
            // from allowing aggressive garbage collection to occur 
            // before the method ends. (See end of method.)
            //System.Timers.Timer aTimer;
    
            // Create a timer with specified interval.
            aTimer = new System.Timers.Timer(interval);
    
            // Hook up the event handler for the Elapsed event.
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Enabled = true;
            // Kick off message handling - don't forget to clean up the timer when 
            // you wish to exit
            while (moreMessages)
            {
               Message message = getNextmessage();
               ProcessMessage(message);
            }
            // cleanup here when messages are drained
            // If the timer is declared in a long-running method, use
            // KeepAlive to prevent garbage collection from occurring
            // before the method ends.
            //GC.KeepAlive(aTimer);        }
    
        private static void OnTimedEvent(object source, ElapsedEventArgs e) 
        {
            object errorEmail = null;
            lock (errors)
            {
                if (errors.Count > trigger)
                {
                   // init message to contain errors here
                   errorEmail = new ErrorEmail();
                   foreach (string err in errors)
                   {
                      // add error info to message
                   } 
                   errors.Clear();
                   trigger = 0;
                }
            }
            if (errorEmail != null)
            {
              // send message outside the lock
              Send(errorEmail);
            }
        }
    }
