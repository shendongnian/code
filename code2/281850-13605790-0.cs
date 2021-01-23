    using System;
    using System.Data.Common;
    using System.Diagnostics;
    using Clutch.Diagnostics.EntityFramework;
    /// <summary>
    /// 
    /// </summary>
    public class DbTracingListener : IDbTracingListener
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="command"></param>
        /// <param name="result"></param>
        /// <param name="duration"></param>
        public void CommandExecuted(DbConnection connection, DbCommand command, object result, TimeSpan duration)
        {
            Debug.WriteLine(command.CommandText);
            Debug.WriteLine(string.Format("Executed in: {0}", duration));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="command"></param>
        public void CommandExecuting(DbConnection connection, DbCommand command)
        {
           
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="command"></param>
        /// <param name="exception"></param>
        /// <param name="duration"></param>
        public void CommandFailed(DbConnection connection, DbCommand command, Exception exception, TimeSpan duration)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="command"></param>
        /// <param name="result"></param>
        /// <param name="duration"></param>
        public void CommandFinished(DbConnection connection, DbCommand command, object result, TimeSpan duration)
        {
        }
    }
