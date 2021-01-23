    public class UnbiasedRandomPicker<T>
    {
        private readonly Random _rand = new Random();
        private readonly T[] _possibilities;
    
        public UnbiasedRandomPicker(params T[] possibilities)
        {
            // sanity checks omitted
            _possibilities = possibilities;
        }
    
        public T GetRandomValue()
        {
            return _possibilities[_rand.Next(_possibilities.Length)];
        }
    }
