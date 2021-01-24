        public class Movie
        {
                public int Id { get; set; }
                public bool IsSpecial { get; set; }
                public IEnumerable<Ticket> Tickets { get; set; }
        }
