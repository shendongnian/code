    public class User
    {
       public int UserId { get; set; }
       public string Username { get; set; }
       public int? ActivationTicketId { get; set;}
       public virtual ActivationTicket ActivationTicket { get; set; }
    }
