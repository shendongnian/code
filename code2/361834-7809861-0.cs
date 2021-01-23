    public class StarTrek
    {
        internal virtual IList<string> Characters
        {
            get
            {
                return new List<string> { Kirk, Spock, Sulu, Scott };
            }
        }
    
        public void ShowEnum()
        {
            string.Join(", ", Characters).Dump();
        }
    }
    public class NewGeneration : StarTrek
    {
        internal override IList<string> Characters
        {
            get
            {
                return new List<string> { Picard, Riker, Worf, Geordi };
            }
        }
    }
