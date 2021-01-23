    public class EntityBase<T>
    {
        public virtual void Save<T>(T dok) where T : EntityBase<T>, new()
        {
        }
    }
    public class Unpaid : EntityBase<Unpaid>
    {
        public override void Save<Unpaid>(Unpaid dok)
        {
            // dok is now of type Unpaid and doesn't need the cast
        }
    }
