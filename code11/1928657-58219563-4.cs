        public StarWarsFigures(string character)
        {
            this.Character = character;
            this.Bounty = rng.Next(1, 10);
        }
        public int Bounty
        {
            get { return bounty; }
            set { bounty = value; }
        }
