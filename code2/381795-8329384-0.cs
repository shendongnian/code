    abstract class Animal
    {
        protected Food favourite;
        protected Animal(Food f) { this.favourite = f; }
    }
    abstract class Food
    {
    }
    sealed class Banana : Food 
    {
        public void Peel() {}
    }
    sealed class Monkey : Animal
    {
        public Monkey(Banana banana) : base(banana) {}
        public PeelMyBanana()
        {
            this.favourite.Peel(); // Error, favourite is of type Food, not Banana
        }
    }
