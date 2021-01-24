    public partial class Connection
    {
        public Connection()
        {
        }
        public int Id { get; set; }
      
        public int StartCityId { get; set; }
        public int EndCityId { get; set; }
        public int AantalMinuten { get; set; }
        public double Prijs { get; set; }     
    }
