    private IEnumerable<Ticket> _tickets;
    public IEnumerable<Ticket> Tickets 
    { 
        get { return _tickets;} 
        set 
        { 
           if(this.IsSpecial)
           {
               _tickets = new List<TicketSpecial>(value.Cast<TicketSpecial>());
           }
           else
           {
               _tickets = new List<Ticket>(value.Cast<Ticket>());
           }
        }
    }
