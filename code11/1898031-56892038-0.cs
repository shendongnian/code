    public Snake : IMonster
    {
        public int Health => 10;
    }
    
    public Hydra : IMonster
    {
        private int[] _healthParts = new [] { 25, 25, 25, 25 };
        public int Health => _healthParts.Sum();
    }
