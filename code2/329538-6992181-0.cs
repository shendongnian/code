    Dictionary<string, string> oddParts = new Dictionary>string, string>();
    Dictionary<string, Timer> timers = new Dictionary<string, Timer>();
    while (serialportopen)
    {
        // somedecoding I end up with
        string hexid;
        string oddpart;
        string evenpart;
        // you need something to identify where the message came from and that is present in both the odd and even part (the BF... of your previous question)
        string msgId;
        if (!String.IsNullOrEmpty(oddpart))
            ProcessOddPart(msgId, oddpart, oddParts, timers);
        else if (!String.IsNullOrEmpty(evenpart))
            hexid = HexIdFromEvenPart(msgId, evenpart, oddparts, timers);
        if (!String.IsNullOrEmpty(hexid))
            Process(hexid);
    }
    void Process(string hexid)
    {
        // your stuff here
    }
    void ProcessOddPart(string msgId, string oddPart, Dictionary<string, string> oddParts, Dictionary<string, Timer> timers)
    {
        oddParts[msgId] = oddPart;
        System.Timers.Timer tmr = new Timer(); 
        timers[msgId = tmr;
        ElapsedEventHandler timePassed = delegate(object anObj, ElapsedEventArgs args) {
            tmr.Stop();
            oddParts.Remove(msgId);
            timers.Remove(msgId);
        };
        tmr.Interval = 10000;
        tmr.Elapsed += timePassed;
        tmr.Start();
    }
    void HexIdFromEvenPart(string msgId, string evenPart, Dictionary<string, string> oddParts, Dictionary<string, Timer> timers)
    {
        string oddPart;
        Timer tmr;
        if (timers.TryGetValue(msgId, out tmr))
        {
            tmr.Stop();
            timers.Remove(msgId);
        }
        if (!oddParts.TryGetValue(msgId, out oddPart))
            return null;
        return oddPart + evenPart;
    }
