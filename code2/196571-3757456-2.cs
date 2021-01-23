    using System;
    using System.Linq;
    using System.Threading;
    using System.Collections.Generic;
    
    namespace Utility
    {
       /// <summary>
       /// Class that is designed to execution Action-based anonymous delegates after a specified
       /// interval.  This class also supports repetitive tasks on an interval.
       /// </summary>
       public static class At
       {
          #region Embedded Classes
    
          /// <summary>
          /// Embedded class definition for common At job periods.
          /// </summary>
          public static class Periods
          {
             #region Members
    
             /// <summary>
             /// Specifies an object that indicates to not restart.
             /// </summary>
             public static readonly TimeSpan DoNotStart = TimeSpan.FromMilliseconds(-1.0);
    
             /// <summary>
             /// Specifies an object that indicates to start immediately.
             /// </summary>
             public static readonly TimeSpan Immediately = TimeSpan.FromMilliseconds(0.0);
    
             /// <summary>
             /// Specifies an interval of one second.
             /// </summary>
             public static readonly TimeSpan SecondsOne = TimeSpan.FromSeconds(1.0);
    
             /// <summary>
             /// Specifies an interval of five seconds.
             /// </summary>
             public static readonly TimeSpan SecondsFive = TimeSpan.FromSeconds(5.0);
    
             /// <summary>
             /// Specifies an interval of fifteen seconds.
             /// </summary>
             public static readonly TimeSpan SecondsFifteen = TimeSpan.FromSeconds(15.0);
    
             /// <summary>
             /// Specifies an interval of thirty seconds.
             /// </summary>
             public static readonly TimeSpan SecondsThirty = TimeSpan.FromSeconds(30.0);
    
             /// <summary>
             /// Specifies an interval of 100ms.
             /// </summary>
             public static readonly TimeSpan MicroDelay = TimeSpan.FromMilliseconds(100);
    
             #endregion
          }
    
          #endregion
    
          #region Members
    
          /// <summary>
          /// Specifies an object that can be used for synchronization.
          /// </summary>
          private readonly static object syncRoot;
    
          /// <summary>
          /// Specifies a collection of Timer object that were created for interval-based execution.
          /// </summary>
          /// <remarks>
          /// We must keep these in a collection to prevent the GC from disposing of the timers.
          /// </remarks>
          private readonly static Dictionary<object, Timer> ActiveTimers;
    
          /// <summary>
          /// Specifies a collection of timestamps of when timers are created.
          /// </summary>
          private readonly static Dictionary<object, DateTime> TimerCreation;
    
          /// <summary>
          /// Specifies an object that will produce pseudo-random numbers.
          /// </summary>
          private readonly static Random RNG;
    
          #endregion
    
          #region Static Constructor
    
          static At()
          {
             syncRoot = new object();
             
             ActiveTimers = new Dictionary<object, Timer>();
             TimerCreation = new Dictionary<object, DateTime>();
    
             RNG = new Random();
    
             // "deconstructor"
             AppDomain.CurrentDomain.DomainUnload += new EventHandler(CurrentDomain_DomainUnload);
    
             return;
          }
    
          /// <summary>
          /// Method used to cleanup resources used by this object.
          /// </summary>
          static void CurrentDomain_DomainUnload(object sender, EventArgs e)
          {
             // dispose of all the timers directly
             At.ActiveTimers.Values.ToList().ForEach(a => a.Dispose());
    
             return;
          }
    
          #endregion
    
          #region Methods
    
          #region At Job Staging
    
          /// <summary>
          /// Method that executes an anonymous method after a delay period.
          /// </summary>
          /// <param name="action">The anonymous method that needs to be executed.</param>
          /// <param name="delay">The period of delay to wait before executing.</param>
          /// <param name="interval">The period (in milliseconds) to delay before executing the anonymous method again (Timeout.Infinite to disable).</param>
          public static Timer Do(Action action, TimeSpan delay, TimeSpan? onInterval = null, object key = null)
          {
             Timer timer;
    
             if (key == null)
             {
                // auto-generate a key
                key = string.Concat("Auto(", At.RNG.NextNonNegativeLong(), ")");
             }
    
             lock (At.ActiveTimers)
             {
                // action - contains the method that we wish to invoke
                At.ActiveTimers.Add(key, timer = new Timer(ActionInvoker, action, delay, onInterval ?? At.Periods.DoNotStart));
                At.TimerCreation.Add(key, DateTime.Now);
             }
    
             //Log.Message
             //(
             //   LogMessageType.Debug,
             //   "[DEBUG] {0}: registered At job (key = {1}, initial delay = {2}, interval = {3})",
             //   action,
             //   key,
             //   delay,
             //   (onInterval == null) ? "never" : onInterval.Value.ToString()
             //);
    
             return timer;
          }
    
          /// <summary>
          /// Method that executes an anonymous method after a delay period.
          /// </summary>
          /// <param name="action">The anonymous method that needs to be executed.</param>
          /// <param name="delay">The period of delay (in milliseconds) to wait before executing.</param>
          /// <param name="interval">The period (in milliseconds) to delay before executing the anonymous method again (Timeout.Infinite to disable).</param>
          public static Timer Do(Action action, int delay, int interval = Timeout.Infinite, object key = null)
          {
             return Do(action, TimeSpan.FromMilliseconds(delay), TimeSpan.FromMilliseconds(interval), key);
          }
    
          /// <summary>
          /// Method that executes an anonymous method after a delay period.
          /// </summary>
          /// <param name="action">The anonymous method that needs to be executed.</param>
          /// <param name="dueTime">The due time when this method needs to be executed.</param>
          /// <param name="interval">The period (in milliseconds) to delay before executing the anonymous method again (Timeout.Infinite to disable).</param>
          public static Timer Do(Action action, DateTime dueTime, int interval = Timeout.Infinite, object key = null)
          {
             if (dueTime < DateTime.Now)
             {
                throw new ArgumentOutOfRangeException("dueTime", "The specified due time has already elapsed.");
             }
    
             return Do(action, dueTime - DateTime.Now, TimeSpan.FromMilliseconds(interval), key);
          }
    
          #endregion
    
          #region At Job Retrieval
    
          /// <summary>
          /// Method that attempts to retrieve a job (Timer object) for a given key.
          /// </summary>
          /// <param name="key">The key that we are getting a job for.</param>
          public static Timer GetJobFor(object key)
          {
             if (key == null)
             {
                throw new ArgumentNullException("key");
             }
    
             lock (At.ActiveTimers)
             {
                if (At.ActiveTimers.ContainsKey(key) == false)
                {
                   /*
                   Log.Message
                   (
                      LogMessageType.Error,
                      "[ERROR] At({0}): unable to find a job with specified key",
                      key
                   );
                   */
                   return null;
                }
    
                return At.ActiveTimers[key];
             }
          }
    
          /// <summary>
          /// Method that ends a job and removes all resources associated with it.
          /// </summary>
          /// <param name="key">The key that we are getting a job for.</param>
          public static void EndJob(object key)
          {
             Timer timer;
    
             if ((timer = GetJobFor(key)) == null)
             {
                // no timer - cannot suspend
                return;
             }
    
             // dispose of the timer object
             timer.Dispose();
    
             lock (At.ActiveTimers)
             {
                // remove the existence from the dictionary
                At.ActiveTimers.Remove(key);
                /*
                Log.Message
                (
                   LogMessageType.Info,
                   "[INFO] At({0}): job has been disposed (created {1}, duration {2})",
                   key,
                   TimerCreation[key].ToISODateTime(),
                   (DateTime.Now - TimerCreation[key]).ToText()
                );
                */
                At.TimerCreation.Remove(key);
             }
    
             return;
          }
    
          /// <summary>
          /// Method that attempts to suspend an active job (using the provided key).
          /// </summary>
          /// <param name="key">The key that we are getting a job for.</param>
          public static void SuspendJob(object key)
          {
             Timer timer;
    
             if ((timer = GetJobFor(key)) == null)
             {
                // no timer - cannot suspend
                return;
             }
    
             // set the timer to not restart
             timer.Change(TimeSpan.FromMilliseconds(-1), TimeSpan.FromMilliseconds(-1));
             /*
             Log.Message
             (
                LogMessageType.Info,
                "[INFO] At({0}): job has been suspended",
                key
             );
             */
             return;
          }
    
          /// <summary>
          /// Method that attempts to resume an active job (using the provided key).
          /// </summary>
          /// <param name="key">The key that we are getting a job for.</param>
          /// <param name="delay">The amount of delay before restarting the job (specify <b>0</b> to restart immediately).</param>
          /// <param name="interval">The delay between intervals (specify <b>-1ms</b> to prevent intervals).</param>
          public static void ResumeJob(object key, TimeSpan delay, TimeSpan interval)
          {
             Timer timer;
    
             if ((timer = GetJobFor(key)) == null)
             {
                // no timer - cannot suspend
                return;
             }
    
             // set the timer to not restart
             timer.Change(delay, interval);
             /*
             Log.Message
             (
                LogMessageType.Info,
                "[INFO] At({0}): job has been resumed (delay = {1}, interval = {2})",
                key,
                delay,
                interval
             );
             */
             return;
          }
    
          #endregion
    
          /// <summary>
          /// Method that invokes an action delegate on a timer.
          /// </summary>
          /// <param name="o">A reference to the action that is to be taken.</param>
          private static void ActionInvoker(object o)
          {
             // invoke the delegate
             (o as Action).Invoke();
    
             return;
          }
    
          #endregion
       }
    }
