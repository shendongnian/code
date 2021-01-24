    public class Measurement<TUnit, TMeasurement>
        where TUnit : struct
        where TMeasurement: Measurement<TUnit, TMeasurement>
    {
        private readonly double _value;
        protected Measurement(double value, TUnit unit)
        {
            _value = value;
            Unit = unit;
        }
        protected double Value { get; set; }
        public TUnit Unit { get; protected set; }
        
        // Conversion Methods - these will get overridden in the derived classes.
        protected virtual double GetValueAs(TUnit unit) => throw new NotImplementedException();
        // Operator overloads
        public static TMeasurement operator +(Measurement<TUnit, TMeasurement> left, Measurement<TUnit, TMeasurement> right)
        {
            //we cannot create new instance of derived class, TMeasurement, which is limitation of generics in C#, so need some workaround there
            //Some kind of clone might be solution for that
            var leftClone = (TMeasurement)left.MemberwiseClone();  
            var resultValue =  leftClone.Value + right.GetValueAs(left.Unit);
            leftClone.Unit = left.Unit;
            leftClone.Value = resultValue;
            return leftClone;
        }
    }
    public struct LengthUnit
    {
        
    }
    public sealed class LengthMeasurement : Measurement<LengthUnit, LengthMeasurement>
    {
        private LengthMeasurement(double value, LengthUnit unit): base(value, unit)
        {
            
        }
        
        public static LengthMeasurement FromMeters(double meters) => throw new NotImplementedException();
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var length1 = LengthMeasurement.FromMeters(5);
            var length2 = LengthMeasurement.FromMeters(10);
            LengthMeasurement length3 = length1 + length2;
        }
    }
