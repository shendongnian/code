    [HttpGet]
    public IEnumerable<string> WatchMe(int record_id)
    {   
       using (var hubConnection = new HubConnection("your local host address")) 
       {
        IHubProxy proxy= hubConnection.CreateHubProxy("GMapChatHub");
         await hubConnection.Start();
        proxy.Invoke("sendHelpMessage",record_id.ToString());     // invoke server method
      } 
    // return sth. IEnumerable<string>
    }
