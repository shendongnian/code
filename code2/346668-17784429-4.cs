        using System;
        
          using NLog;
          using NLog.Config;
        
          /// <summary>
          ///     The logging service.
          /// </summary>
          public class Logger : NLog.Logger, ILogger
          {
              #region Fields
        
              private string _loggerName;
        
              #endregion
        
              #region Public Methods and Operators
        
              /// <summary>
              ///     The get logging service.
              /// </summary>
              /// <returns>
              ///     The <see cref="ILogger" />.
              /// </returns>
              public ILogger CreateLogger(Type type)
              {
                  if (type == null) throw new ArgumentNullException("type");               
        
                  _loggerName = type.FullName;
        
                  var logger = (ILogger)LogManager.GetLogger(_loggerName, typeof(Logger));
        
                  return logger;
              }
