    class Money
    {
        public int Dollar {get; set;}
        public int Cent { get; set;}
    
        public Money(int cents)
        {
            this.Dollar = Math.Floor(cents/100);
            this.Cent = cents%100;
        }
    }
