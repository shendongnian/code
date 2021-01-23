    protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
    {
        string msg = loggingEvent.RenderedMessage;
        // remove the password if there is any
        writer.Write(msg);
    }
