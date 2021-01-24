    class Dice
    {
        private readonly Random rnd;
        public int Amount { get; set; }
        public int ThrowAmount { get; set; }
        public Dice(int throwamount)
        {
            ThrowAmount = throwamount;
            rnd = new Random();
        }
        public void Throw() => Amount = rnd.Next(1, 7); //Random() max value is exclusive
    }
