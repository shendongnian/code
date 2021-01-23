        public interface Applyable<T>
        {
            void Apply(T input);
            T GetValue();
        }
        public abstract class Convertable<T>
        {
            public dynamic value { get; set; }
            public Convertable(dynamic value)
            {
                this.value = value;
            }
            public abstract T GetConvertedValue();
        }        
        public class IntableInt : Convertable<int>, Applyable<int>
        {
            public IntableInt(int value) : base(value) {}
            public override int GetConvertedValue()
            {
                return value;
            }
            public void Apply(int input)
            {
                value += input;
            }
            public int GetValue()
            {
                return value;
            }
        }
        public class IntableDouble : Convertable<int>
        {
            public IntableDouble(double value) : base(value) {}
            public override int GetConvertedValue()
            {
                return (int) value;
            }
        }
        public class IntableString : Convertable<int>
        {
            public IntableString(string value) : base(value) {}
            public override int GetConvertedValue()
            {
                // If it can't be parsed return zero
                int result;
                return int.TryParse(value, out result) ? result : 0;
            }
        }
        private static void ApplyToFirst<TResult>(ref Applyable<TResult> first, params Convertable<TResult>[] args)
        {
            foreach (var arg in args)
            {                
                first.Apply(arg.GetConvertedValue());  
            }
        }
        static void Main(string[] args)
        {
            Applyable<int> result = new IntableInt(0);
            IntableInt myInt = new IntableInt(1);
            IntableDouble myDouble1 = new IntableDouble(1.5);
            IntableDouble myDouble2 = new IntableDouble(2.0);
            IntableDouble myDouble3 = new IntableDouble(3.5);
            IntableString myString = new IntableString("2");
            ApplyToFirst(ref result, myInt, myDouble1, myDouble2, myDouble3, myString);
            Console.WriteLine(result.GetValue());
            Console.ReadKey();
        }
