        public class Ticket
        {
            public int ID { get; set; }
            [Required]
            public string Klant { get; set; }
            [Required]
            public string Applicatie { get; set; }
            [Required]
            public string Onderwerp { get; set; }
            [Required]
            public string Omschrijving { get; set; }
            public DateTime Datum { get; set; }
            public string Status { get; set; }
            public string IdentityUserId { get; set; }
            public virtual IdentityUser IdentityUser { get; set; }
        }
