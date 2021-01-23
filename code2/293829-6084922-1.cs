    public static class UtilityManager
    {  
        static UtilityManager()
        {
            Ticket = new TicketProvider();
        }
    
        public static TicketProvider Ticket { get; private set; }
    
        public static int GetServiceTicketNumber()
        {       
            return Ticket.GetTicket();
        }
    }
