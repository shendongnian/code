    public static class UtilityManager
    {  
        static UtilityManager()
        {
            _ticket = new TicketProvider();
        }
    
        private static TicketProvider _ticket;
    
        public static int GetServiceTicketNumber()
        {       
            return _ticket.GetTicket();
        }
    }
