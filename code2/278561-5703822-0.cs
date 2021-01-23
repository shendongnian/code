    class Organism
    {
        public bool Found
        {
            get;
            set;
        }
    }
    class Something : Organism
    {
        public Something()
        {
            this.Found = true;
        }
    }
    public class Program
    {
        public int countFound<T>(List<T> Organisms)
            where T : Organism
        {
            foreach (T organism in Organisms)
            {
                if (organism.Found)
                {
                    // Do something with the organism
                }
            }
            return 0;
        }
    }
