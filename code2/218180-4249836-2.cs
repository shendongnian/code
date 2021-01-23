    [LayoutRenderer("ExtendedException")]
        public class ExtendedExceptionLayoutRenderer : ExceptionLayoutRenderer
        {
            protected override void Append(System.Text.StringBuilder builder, LogEventInfo logEvent)
            {
                base.Append(builder, logEvent);
                
                var exception = logEvent.Exception;
                if (exception is SocketException)
                {
                    var sockException = (SocketException) exception;
                    builder.Append(sockException.ErrorCode).Append(" ").Append(sockException.SocketErrorCode);
                }
            }
        }
