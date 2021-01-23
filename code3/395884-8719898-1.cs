    internal sealed class CharacterManager
    {
        private readonly object locker = new object();
        private readonly IList<Character> characters = new List<Character>();
        public ReadOnlyCollection<Character> Characters
        {
            get
            {
                lock (this.locker)
                {
                    return this.characters.AsReadOnly();
                }
            }
        }
        public void Add(Character character)
        {
            lock (this.locker)
            {
                this.characters.Add(character);
            }
        }
        public void Remove(Character character)
        {
            lock (this.locker)
            {
                this.characters.Remove(character);
            }
        }
    }
