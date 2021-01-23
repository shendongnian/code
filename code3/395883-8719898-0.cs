    internal sealed class CharacterManager
    {
        private readonly object locker = new object();
        private readonly IList<Character> characters = new List<Character>();
        public ReadOnlyCollection<Character> Characters
        {
            get
            {
                lock (locker)
                {
                    return new ReadOnlyCollection<Character>(this.characters);
                }
            }
        }
        public void Add(Character character)
        {
            lock (locker)
            {
                this.characters.Add(character);
            }
        }
        public void Remove(Character character)
        {
            lock (locker)
            {
                this.characters.Remove(character);
            }
        }
    }
