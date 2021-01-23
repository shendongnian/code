    string[] parameters = null;
    string[] values = null;
    // string SourceString = "<parameter1(value1)><parameter2(value2)><parameter3(value3)>";
    string SourceString = @"<QUEUE(C2.BRH.ARB_INVPUSH01)><CHANNEL(C2.MONITORING_CHANNEL)><QMGR(C2.MASTER_NA‌​ME.TRACKER)>";
    // string regExpression = @"<([^\(]+)[\(]([\w]+)";
    string regExpression = @"<([^\(]+)[\(]([^\)]+)";
    Regex r = new Regex(regExpression);
    MatchCollection collection = r.Matches(SourceString);
    parameters = new string[collection.Count];
    values = new string[collection.Count];
    for (int i = 0; i < collection.Count; i++)
    {
        Match m = collection[i];
        parameters[i] = m.Groups[1].Value;
        values[i] = m.Groups[2].Value;
    } 
