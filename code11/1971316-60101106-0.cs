    public abstract class Armor { }
    public sealed class Armor<TSlot> : Armor
        where TSlot : Slot, new()
    {
        public TSlot Slot { get; }
        public Armor() => Slot = new TSlot();
    }
