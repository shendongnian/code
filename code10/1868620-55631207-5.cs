    public partial class Connection
    {
        public Connection()
        {
        }
        public int Id { get; set; }
      
        public ICollection<City> Cities { get; set; }
        public int AantalMinuten { get; set; }
        public double Prijs { get; set; }     
    }
