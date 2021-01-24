    public sealed class SafeDictionary
    {
        private readonly Dictionary<Slot, Armor> _dictionary = new Dictionary<Slot, Armor>();
        public Armor this[Slot slot] => _dictionary[slot];
        public void Add<TSlot>(TSlot slot, Armor<TSlot> armor)
            where TSlot : Slot, new()
        {
            _dictionary.Add(slot, armor);
        }
    }
