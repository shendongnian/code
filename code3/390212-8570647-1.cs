    public static String ParseMessage(String message)
    {
        var parser = new NHapi.Base.Parser.PipeParser();
        var parsedMessage = parser.Parse(message);
        //Get the message type and trigger event
        var msgType = parsedMessage.GetStructureName();
        //Get the message in raw, pipe-delimited format
        var pipeDelimitedMessage = parser.Encode(parsedMessage);
        return pipeDelimitedMessage;
    }
