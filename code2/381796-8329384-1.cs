    sealed class Monkey : Animal
    {
        public Monkey(Banana banana) : base(banana) {}
        
        private Banana Favourite { get { return (Banana)this.favourite; } }        
        public PeelMyBanana()
        {
            this.Favourite.Peel(); // Works
        }
    }
