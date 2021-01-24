    public class Rider
    {
        public int Id { get; set; }
        public EquineBeast Mount { get; set; }
    }
    
    public enum EquineBeast
    {
        Donkey,
        Mule,
        Horse,
        Unicorn
    }
