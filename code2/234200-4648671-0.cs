    [MetadataType(typeof (TicketMetadata))]
      public partial class Ticket
      {
        internal sealed class TicketMetadata
        {
          [Key] public int TicketId;
    
          [Required]
          public DateTime IncidentDate;
    
          [Required(ErrorMessage = "Missing Customer")] 
          public int CustomerId;
    
          [Required(ErrorMessage = "Missing Product")] 
          public int ProductId; 
    
          [Include]
          [Association("Ticket_Customer", "CustomerId", "CustomerId", IsForeignKey = true)]
          public Customer Customer;
    
          [Include]
          [Association("Ticket_Product", "ProductId", "ProductId", IsForeignKey = true)]
          public Product Product;
    
          [Include]
          [Composition]
          [Association("Ticket_TicketActions", "TicketId", "TicketId")]
          public List<TicketAction> TicketActions;
        }
      }
