    internal sealed class CharacterManager
    {
        private readonly IList<Character> characters = new List<Character>();
        public ReadOnlyCollection<Character> Characters
        {
            get
            {
                lock (this.characters)
                {
                    return this.characters.AsReadOnly();
                }
            }
        }
        public void Add(Character character)
        {
            lock (this.characters)
            {
                this.characters.Add(character);
            }
        }
        public void Remove(Character character)
        {
            lock (this.characters)
            {
                this.characters.Remove(character);
            }
        }
    }
