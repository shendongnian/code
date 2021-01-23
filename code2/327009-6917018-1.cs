    public class InstanceList : List<Instance>, ICloneable<InstanceList>
    {
        public InstanceList Clone()
        {
            // Implement cloning guts here.
        }
        object ICloneable.Clone()
        {
            return ((ICloneable<InstanceList>) this).Clone();
        }
    }
    public class Instance
    {
        
    }
    public interface ICloneable<T> : ICloneable where T : ICloneable<T>
    {
        new T Clone();
    }
