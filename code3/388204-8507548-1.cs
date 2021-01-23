    var sb = new StringBuilder();
    sb.Append("Header");
    sb.Append(Environment.NewLine);
    sb.Append("Message");
    ...
    var msg = sb.ToString();
    
    ILog log = //resolve ILog
    log.Debug(msg);
