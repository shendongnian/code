    public class Base
    {
        private static Dictionatry<Type,int> _values;
        
        public int MyMethod()
        {
            _values[this.GetType()]+=5;
            return _values[this.GetType()];
        }
    }
