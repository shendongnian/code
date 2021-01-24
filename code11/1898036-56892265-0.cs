    class Snake
    {
        public virtual int Health { get; }
    }
    class Hydra : Snake
    {
        public int[] Healths { get; }
        public override int Health
        {
            get
            {
                // Or whatever is meaningful
                return (int)Healths.Average();
            }
        }
    }
