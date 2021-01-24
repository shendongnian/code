    public class Bilgi
    {
        public string Id {get;set;}
        public string insankaynagi { get; set; }
        public string birim { get; set; }
        public string miktar { get; set; } 
        
    }
    public DbSet<Bilgi> Bilgis{ get; set; }
