        using System;
        using System.ComponentModel.Composition;
     
        [Export(typeof(ILogFactory))]
        [PartCreationPolicy(CreationPolicy.Shared)]
        public class LogFactory : ILogFactory
        {
            #region Public Methods and Operators
     
            public ILogger Create(Type type)
            {
                var logger = new Logger().CreateLogger(type);
                return logger;
            }
     
            #endregion
        }
