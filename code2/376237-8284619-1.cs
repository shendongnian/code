    public class DataField<T> : DataField 
    {
        public T Value { get; set; }
        public override double Sum(double sum)
        {
           if (typeof(T) == typeof(int))
           {
               return sum + (int)Value; // Cannot really cast here!
           }
           else if (typeof(T) == typeof(float))
           {
               return sum + (float)Value; // Cannot really cast here!
           }
           // ...
           return sum;
        }
    }
