    public class MyModel
    {
         public DateTime datetime { get; set; }
         public List<Kursi> Kursi { get; set; }
         public List<Bunga> Bunga { get; set; }
    }
    
    public class Kurski
    {
         public int kursi_id { get; set; }
         public int kursi_value { get; set; }
    }
    
    public class Bunga
    {
         public int bunga_id { get; set; }
         public string bunga_value { get; set; }
    }
