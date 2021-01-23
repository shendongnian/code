    private void UpdateList(Client client)
    {
        var listUpdateReceive = Observable
            .FromEvent<ListEventArgs>(ev => client.ListUpdateReceive += ev, ev => client.ListUpdateReceive -= ev);
    
        listUpdateReceive.Subscribe(r =>
            {
               TraceInformation("List is updated.");
    
               OnListUpdateReceived(r.Sender, r.EventArgs);
            });
    }
