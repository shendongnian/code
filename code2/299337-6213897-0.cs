    var ev = new EventLog("system", System.Environment.MachineName);
    int count = 0;
    var y = DateTime.Now.AddDays(-1);
    for (int i = ev.Entries.Count - 1; i >= 0 ; i--)
    {
    	if(ev.Entries[i].TimeGenerated < y)
    		break;
    	if(ev.Entries[i].Source.Equals("USER32", StringComparison.CurrentCultureIgnoreCase))
    		count++;
    }
