    public class PasswordObfuscationAppender : AppenderSkeleton
    {
        private static readonly FieldInfo LoggingEventmDataFieldInfo = typeof(LoggingEvent).GetField(
            "m_data",
            BindingFlags.Instance | BindingFlags.NonPublic);
        protected override void Append(LoggingEvent loggingEvent)
        {
            var originalRenderedMessage = loggingEvent.RenderedMessage;
            var newMessage = GetModifiedMessage(originalRenderedMessage);
            if (originalRenderedMessage != newMessage)
                SetMessageOnLoggingEvent(loggingEvent, newMessage);
        }
        /// <summary>
        /// I couldn't figure out how to 'naturally' change the log message, so use reflection to change the underlying storage of the message data
        /// </summary>
        private static void SetMessageOnLoggingEvent(LoggingEvent loggingEvent, string newMessage)
        {
            var loggingEventData = (LoggingEventData)LoggingEventmDataFieldInfo.GetValue(loggingEvent);
            loggingEventData.Message = newMessage;
            LoggingEventmDataFieldInfo.SetValue(loggingEvent, loggingEventData);
        }
        private static string GetModifiedMessage(string originalMessage)
        {
            // TODO modification implementation
            return originalMessage;
        }
    }
