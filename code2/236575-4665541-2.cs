    public abstract class Loot : ICloneable
    {
        public virtual object Clone()
        {
            Type type = this.GetType();
            Loot newLoot = (Loot) Activator.CreateInstance(type);
            //do copying here
            return newLoot;
        }
    }
