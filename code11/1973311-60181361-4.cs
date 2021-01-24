    public virtual Task OnConnected(WebSocket socket, HttpContext context)
    {
       string connectionId = CreateConnectionId(context);
    
       ConnectionManager.AddSocket(connectionId, socket);
       return Task.CompletedTask;
    }
