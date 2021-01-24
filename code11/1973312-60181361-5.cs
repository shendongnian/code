    public virtual  Task OnConnected(WebSocket socket, HttpContext context)
    {
       try
       {
          string connectionId = CreateConnectionId(context);
    
          ConnectionManager.AddSocket(connectionId, socket);
                  
          // more stuff
          return Task.CompletedTask;
       }
       catch (Exception e)
       {
          return Task.FromException(e);
       }   
    }
