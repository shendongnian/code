    public class Dice
    {
        private List<IDiceObserver> observers;
        public void RegisterObserver(IDiceObserver observer)
        {
            this.observers.Add(observer);
        }
        private Int32 count;
        public Int32 Count
        {
            get
            {
                return this.count;
            }
            private set
            {
                this.count = value;
                foreach (IDiceObserver observer in this.observers)
                    observer.DiceRolled(new DiceParameters(this.count));
            }
        }
        public void RollDice()
        {
            this.Count = new Random(DateTime.Now.Millisecond).Next();
        }
        public Dice()
        {
            this.observers = new List<IDiceObserver>();
        }
    }
