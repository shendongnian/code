    public class star_wars_figures
    {
        static readonly Random rnd = new Random();
        private string charactor;
        private int bounty;
        public star_wars_figures(string charactor)
        {
            Charactor = charactor;            }
        public string Charactor
        {
            get
            {
                return charactor.ToUpper();
            }
            set
            {
                if (value == "Han Solo" || value == "Leia")
                {
                    charactor = value;
                }
                else charactor = "INCORRECT CHARACTOR!!!!";
            }
        }
        public void SetRandomBounty()
        {
             bounty = rng.Next(1,10);
        }
        public int Bounty
        {
            get
            {
                return bounty;
            }
            set
            {
                bounty = value;
            }
        }
    }
