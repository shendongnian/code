    public partial class City
    {
        public City()
        {           
            Connections = new HashSet<Connection>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public ICollection<Connection> Connections { get; set; }
    }
