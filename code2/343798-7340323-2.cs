    public abstract class Base : ICloneable
    {
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
