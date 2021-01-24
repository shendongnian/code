    namespace OptiLeadInfrastructure.Models
    {
        public class ClientDTO
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public string Email { get; set; }
            public Nullable<short> Type { get; set; }
            public string logo { get; set; }
            public Nullable<DateTime> CreatedOn { get; set; }
            public string CreatedBy { get; set; }
            public Nullable<DateTime> LastModifiiedOn { get; set; }
            public virtual ICollection<ClientDetailDTO> ClientDetails { get; set; }
        }   public string LastModifiedBy { get; set; }
         
    }
