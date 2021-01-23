        public enum ValueType
        {
            String = 0,
            Integer = 1,
            CustomDataType = 3
        }
    
        public interface IValueType : IComparer<object>
        {
            string ToString(object obj);
        }
    
        public class IntegerValueType : IValueType
        {
            public int Compare(object left, object right)
            {
                return ((int)left).CompareTo((int)right);
            }
    
            public string ToString(object obj)
            {
                return ((int)obj).ToString();
            }
        }
    
        public class StringValueType : IValueType
        {
            public int Compare(object left, object right)
            {
                return ((string)left).CompareTo((string)right);
            }
    
            public string ToString(object obj)
            {
                return ((string)obj).ToString();
            }
        }
    
        public class Value : IComparable<Value>
        {
            private object value;
            private IValueType valueType;
    
            public Value(object value, IValueType valueType)
            {
                this.value = value;
                this.valueType = valueType;
            }
    
            public static implicit operator Value(string value)
            {
                return ValueFactory.Create(value, ValueType.String);
            }
    
            public int CompareTo(Value obj)
            {
                return this.valueType.Compare(this.value, obj.value);
            }
    
            public static bool operator <(Value left, Value right)
            {
                return left.CompareTo(right) == -1;
            }
    
            public static bool operator >(Value left, Value right)
            {
                return left.CompareTo(right) == 1;
            }
    
            public static bool operator ==(Value left, Value right)
            {
                return left.CompareTo(right) == 0;
            }
    
            public static bool operator !=(Value left, Value right)
            {
                return left.CompareTo(right) != 0;
            }
    
            public override string ToString()
            {
                return this.valueType.ToString(this.value);
            }
        }
    
        public class ValueFactory
        {
            private static IDictionary<object, IValueType> _valueTypes =
                new Dictionary<object, IValueType>();
    
            static ValueFactory()
            {
                _valueTypes.Add(ValueType.String, new StringValueType());
                _valueTypes.Add(ValueType.Integer, new IntegerValueType());
            }
    
            public static Value Create(object value, object valueType)
            {
                //
                // This logic could be extended to find a ValueType that supports
                // one of the types in the objects inheritance tree. This would
                // also require creating an ObjectValueType, which would be a last
                // resort in the case of the object type not being supported.
                //
                if (!_valueTypes.ContainsKey(valueType))
                    throw new ArgumentException("valueType is not supported");
    
                return new Value(value, _valueTypes[valueType]);
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                int x = 32;
                int y = 16;
    
                Value cx = ValueFactory.Create(x, ValueType.Integer);
                Value cy = ValueFactory.Create(y, ValueType.Integer);
    
                Console.WriteLine("cx = "+cx);
                Console.WriteLine("cy = "+cy);
                Console.WriteLine("x<y = {0}", cx < cy);
                Console.WriteLine("x>y = {0}", cx > cy);
                Console.WriteLine("x==y = {0}", cx == cy);
                Console.WriteLine("x!=y = {0}", cx != cy);
    
                Value name = ValueFactory.Create("Jeffrey Schultz", ValueType.String);
                Console.WriteLine("{0} == You = {1}", name, name == "You");
    
                Console.ReadLine();
            }
        }
