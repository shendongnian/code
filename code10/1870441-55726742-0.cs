    // Write the start element
    writer.WriteStartElement("App");
    writer.WriteStartElement("event");
    writer.WriteAttributeString("logger", loggingEvent.LoggerName);
    .
    .
    .
    .
    writer.WriteEndElement();
    writer.WriteEndElement();
