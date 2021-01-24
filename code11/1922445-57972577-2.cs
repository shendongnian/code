    public class Movie
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public virtual Person Director { get; set; }
        public virtual TypesOfGenre Genre { get; set; }
        public long Length { get; set; }
        public DateTime Year { get; set; }
        public virtual Country CountryName { get; set; }
        public virtual ICollection<Person> Actors { get; set; }
        //Configure enity:
        public int DirectorId { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<MovieProducer> MovieProducers { get; set; }
    }
    
    public class Producer
    {
        public int Id { get; private set; }
        public string CompanyName { get; set; }
        public DateTime YearEstablished { get; set; }
        public long EstimatedCompanyValue { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
        //Configure enity:
        public virtual Country Country { get; set; }
        public virtual ICollection<MovieProducer> MovieProducers { get; set; }
    }
    public class MovieProducer
    {
        public int ProducerId { get; set; }
        public virtual Producer Producer { get; set; }
    
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }
