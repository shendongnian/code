    public abstract class TypeSafeEnumBase
    {
        protected readonly string Name;
        protected readonly int Value;
        protected TypeSafeEnumBase(int value, string name)
        {
            this.Name = name;
            this.Value = value;
        }
        public override string ToString()
        {
            return Name;
        }
    }
