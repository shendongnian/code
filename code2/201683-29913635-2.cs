    using System.Reflection;
    using log4net.Appender;
    using log4net.Core;
	class MessageModifyingForwardingAppender : ForwardingAppender
	{
		private static FieldInfo _loggingEventm_dataFieldInfo;
		public MessageModifyingForwardingAppender()
		{
			_loggingEventm_dataFieldInfo = typeof(LoggingEvent).GetField("m_data", BindingFlags.Instance | BindingFlags.NonPublic);
		}
		protected override void Append(LoggingEvent loggingEvent)
		{
			var originalRenderedMessage = loggingEvent.RenderedMessage;
			var newMessage = GetModifiedMessage(originalRenderedMessage);
			
			if (originalRenderedMessage != newMessage)
				SetMessageOnLoggingEvent(loggingEvent, newMessage);
			base.Append(loggingEvent);
		}
		/// <summary>
		/// I couldn't figure out how to 'naturally' change the log message, so use reflection to change the underlying storage of the message data
		/// </summary>
		private static void SetMessageOnLoggingEvent(LoggingEvent loggingEvent, string newMessage)
		{
			var loggingEventData = (LoggingEventData)_loggingEventm_dataFieldInfo.GetValue(loggingEvent);
			loggingEventData.Message = newMessage;
			_loggingEventm_dataFieldInfo.SetValue(loggingEvent, loggingEventData);
		}
		private static string GetModifiedMessage(string originalMessage)
		{
			// TODO modification implementation
			return originalMessage;
		}
	}
