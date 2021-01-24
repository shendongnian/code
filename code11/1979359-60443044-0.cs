    public class Movie
    {
        public Movie()
        {
            this.Actors = new HashSet<Actor>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime AddDate { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
        
        public string ActorsToString
        {
            get
            {
                string _resultSet = "";
                if (Actors != null && Actors.Count > 0)
                {
                    foreach (Actor _actor in Actors)
                    {
                        _resultSet += $"{_actor.Name}, ";
                    }
                }
                return _resultSet;
            }
        }
    }
