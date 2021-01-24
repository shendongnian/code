        public void SetRandomBounty()
        {
            bounty = rng.Next(1, 10);
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
