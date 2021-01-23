    abstract class Animal<F> where F : Food
    {
        protected F favourite;
        protected Animal(F f) { this.favourite = f; }
    }
    abstract class Food
    {
    }
    sealed class Banana : Food 
    {
        public void Peel() {}
    }
    sealed class Monkey : Animal<Banana>
    {
        public Monkey(Banana banana) : base(banana) {}
        public PeelMyBanana()
        {
            this.favourite.Peel(); // Legal; Animal<Banana>.favourite is of type Banana
        }
    }
