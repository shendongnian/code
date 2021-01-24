    public class TicketService : ITicketService
    {
        // .... 
    	// I expect that you'll be able to get some information about the current user
    	
    	
        public CurrentUserData CurrentUser {get; private set;}
    	
        public TicketChange ChangeTicketDate(TicketChangeCommand command){
                // 1. Load the Aggregate Root from the Data StoreCheck
    			var ticket = db.GetById(ticketId);
    			
    			// 2. Do some Application level checks
    			// 3. Check if the current user is Admin
    			if(CurrentUser.IsAdmin)
    				ticket.ChangeTicketDate();
    			else	
    				ticket.ChangeTicketDate(CurrentUser.Username);
        }
        ....
    }
    
    
    //Example of Domain Model class
    public class Ticket : Entity<Guid>
    {
        public UserInfo Creator {get; private set;}
    
        public void ChangeTicketDate(string requestedUsername){
                if(!string.IsNullOrEmpty(requestedUsername) && requestedUsername != Creator.UserName)
    				threw new ValidationException("You're not allowed to do ChangeTicketDate");
        }
        ....
    }
