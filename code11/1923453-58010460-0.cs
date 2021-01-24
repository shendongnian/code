    public class Obj
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public string Key => string.Compare(Source, Destination) > 0 ? 
                                  Source + "," + Destination : Destination + "," + Source;
     }
