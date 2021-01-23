    using System;
    using System.Text;
    using NLog;
    
    namespace LoggerWrapper
    {    
      /// <summary>    
      /// Provides methods to write messages with event IDs - useful for the Event Log target.    
      /// Wraps a Logger instance.    
      /// </summary>    
      class MyLogger    
      {        
        private Logger _logger;        
    
        public MyLogger(string name)        
        {            
          _logger = LogManager.GetLogger(name);        
        }        
    
        public void WriteMessage(string eventID, string message)           
        {            
          ///            
          /// create log event from the passed message            
          ///             
          LogEventInfo logEvent = new LogEventInfo(LogLevel.Info, _logger.Name, message);
    
    
          //
          // set event-specific context parameter            
          // this context parameter can be retrieved using ${event-context:EventID}            
          //            
          logEvent.Context["EventID"] = eventID;            
          //             
          // Call the Log() method. It is important to pass typeof(MyLogger) as the            
          // first parameter. If you don't, ${callsite} and other callstack-related             
          // layout renderers will not work properly.            
          //            
          _logger.Log(typeof(MyLogger), logEvent);        
        }    
      }
    }
