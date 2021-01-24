    System.IO.StringWriter log = new System.IO.StringWriter();
    log.WriteLine("some text");
    log.WriteLine("more text");
    
    // some how remove the first line ????
    
    var sb = log.GetStringBuilder(); //get the underlying StringBuilder
    var newLinePosition = sb.ToString().IndexOf(Environment.NewLine); //find the first newline
    sb.Remove(0, newLinePosition + Environment.NewLine.Length); //remove from start to the newline... including the newline itself
