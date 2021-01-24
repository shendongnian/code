    public override async Task OnConnected()
    {        
        await AddToGroup("stockGroup");
    
        string name = Context.User.Identity.Name;
        _connections.Add(name, Context.ConnectionId);
        await base.OnConnected();
    }
