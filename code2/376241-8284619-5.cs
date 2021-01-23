    public abstract class DataField
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public abstract double Sum(double sum);
    }
    public class IntDataField : DataField
    {
        public override double Sum(double sum)
        {
            return (int)Value + sum;
        }
    }
    public class FloatDataField : DataField
    {
        public override double Sum(double sum)
        {
            return (float)Value + sum;
        }
    }
