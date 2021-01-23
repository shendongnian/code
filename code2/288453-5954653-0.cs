        /// <summary>
        /// Any additional layers between this log class and calling classes will cause 
        /// this stack trace to return incorrect 'calling' method name
        /// </summary>
        /// <returns></returns>
        private static string GetCallingMethod()
        {
            var stack = new StackTrace();
            var className = string.Empty;
            var methodName = string.Empty;
            foreach ( var frame in stack.GetFrames() )
            {
                className = frame.GetMethod().DeclaringType.FullName;
                methodName = frame.GetMethod().Name;
                if ( className != typeof( Logger ).FullName )
                {
                    break;
                }
            }
            return string.Format( "{0}.{1}", className, methodName );
        }
