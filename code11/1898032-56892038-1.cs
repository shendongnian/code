    public Snake : IMonster
    {
        public int Health {get; set;}
    }
    
    public Hydra : IMonster
    {
        public int HeadHealth {get; set;}
        public int BodyHealth {get; set;}
        public int Health => HeadHealth + BodyHealth;
    }
