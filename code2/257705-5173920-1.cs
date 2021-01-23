    struct Key
    {
        public readonly string Name;
        public readonly int Term;
        public Key(Campaign camp)
        {
            Name = camp.CampaignName;
            Term = camp.Term;    
        }
    }
