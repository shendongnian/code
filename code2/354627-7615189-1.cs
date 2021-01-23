    struct PackedValue
    {
        private PackedValue(ushort val)
        {
             if(val >= (1<<12)) throw new ArgumentException();
             this.Value = val;
        }
        public ushort Value { get; private set; }
        public static explicit operator PackedValue(ushort value){
            return new PackedValue(value);
        }
        
        public static implicit operator ushort(PackedValue me){
            return me.Value;
        }
    }
