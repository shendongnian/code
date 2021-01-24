        public class Ticket : IEquatable<Ticket>
        {
            public int Id { get; set; }
            public string UserEmail { get; set; }
            public int CinemaId { get; set; }
            public int MovieId { get; set; }
            public int CinemaHallId { get; set; }
            public string Row { get; set; }
            public int Seat { get; set; }
            public DateTime TimeOfSeance { get; set; }
            public int Price { get; set; }
            public Boolean Equals(Ticket other)
            {
                return
                    (this.Id == other.Id) &&
                    (this.CinemaId == other.CinemaId) &&
                    (this.MovieId == other.MovieId) &&
                    (this.CinemaHallId == other.CinemaHallId) &&
                    (this.Row == other.Row) &&
                    (this.Seat == other.Seat) &&
                    (this.TimeOfSeance == other.TimeOfSeance);
            }
        }
