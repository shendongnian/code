    public static void InfoWithCallerInfo(this ILog logger, 
        object message, Exception e = null, [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
    {
        if (!logger.IsInfoEnabled)
            return;
        if (e == null)
            logger.Info(string.Format("{0}:{1}:{2} {3}", sourceFilePath, 
                memberName, sourceLineNumber, message));
        else
            logger.Info(string.Format("{0}:{1}:{2} {3}", sourceFilePath, 
                memberName, sourceLineNumber, message), e);
    }
