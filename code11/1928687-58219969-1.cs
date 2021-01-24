    public class InventoryComparer: IEqualityComparer<Inventory>
    {
        public override bool Equals(Inventory a, Inventory b)
        {
            return a.name == b.Id
                && a.id == b.id
                && a.year == b.year;
        }
        public override int GetHashCode(Inventory inventory)
        {
            return inventory.id.GetHashCode();
        }
    }
