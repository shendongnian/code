    static tokenSource = new CancellationTokenSource();
    static CancellationToken ct = tokenSource.Token;
    static Task task = null;
    
    public void HitTimer(int leagueid,int dposition,int teamid,int round)
    {
        if (task != null)
            tokenSource.Cancel();
    
        try
        {
            if (task != null)
                task.Wait();
        }
        catch (AggregateException e)
        {
            foreach (var v in e.InnerExceptions)
                Console.WriteLine(e.Message + " " + v.Message);
        }
    
        task = Task.Factory.StartNew(() => DoLoop(leagueid, dposition, teamid, round), tokenSource.Token)
    }
    
    public void DoLoop(int leagueid,int dposition,int teamid,int round)
    {
        int m = 1;
        for (int k = 1; k < 91; k++)
        {
            if (ct.IsCancellationRequested)
            {
                break;
            }
    
            System.Threading.Thread.Sleep(1000);
            if (k == 90)
            {
                AutoAddDraftPlayer(leagueid, dposition,teamid,round); 
    
            }
            else if (_hubContext != null)
            {
    
                    _hubContext.Clients.All.broadcastTime(90 - k, leagueid, teamid, round);
    
    
    
                //hubContext.Clients.Client(Context.ConnectionId).broadcastTime(90 - k);
                //Clients.Caller.broadcastTime(90 - k);
            }
            m++;
        }
    }
