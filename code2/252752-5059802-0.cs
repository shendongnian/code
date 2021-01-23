    public struct SimpleTuple<TValue1, TValue2>
    {
        private readonly TValue1 _Value1;
        private readonly TValue2 _Value2;
        
        public SimpleTuple(TValue1 value1, TValue2 value2)
        {
            _Value1 = value1;
            _Value2 = value2;
        }
        
        public TValue1 Value1 { get { return _Value1; } }
        public TValue2 Value2 { get { return _Value2; } }
        
        public int GetHashCode()
        {
            unchecked
            {
                int result = 37;
                
                result *= 23;
                if Value1 != null)
                    result += Value1.GetHashCode();
                    
                result *= 23;
                if (Value2 != null)
                    result += Value2.GetHashCode();
                    
                return result;
            }
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(SimpleTuple<TValue1, TValue2>))
                return false;
                
            var other = (SimpleTuple<TValue1, TValue2>)obj;
            return Equals(other.Value1, Value1) && Equals(other.Value2, Value2);
        }
    }
