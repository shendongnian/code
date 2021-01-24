    public class Vak
    {
        public string naamVanVak { get; set; }; 
        public int theorieCijfer { get; set; };
        public PraktijkBeoordeling enumPraktijkBeoordeling { get; set; }; //you need to add this one
    
        public enum PraktijkBeoordeling
        {
            Geen, Absent, Onvoldoende, Voldoende, Goed
        }
    }
