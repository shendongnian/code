        interface ISIConversionSubscriber
        {
            void Register(Action<string, double> regitration);
        }
    
        static class SIConversion<T> where T : ISIConversionSubscriber, new()
        {
    
            private static Dictionary<string, double> myConvertableUnits = new Dictionary<string, double>();
    
            static SIConversion() {
                T subscriber = new T();
                subscriber.Register(registrationAction);
            }
    
            public static double GetFactor(string baseUnit)
            {
                return myConvertableUnits[baseUnit];
            }
    
            private static void registrationAction(string baseUnit, double value)
            {
                myConvertableUnits.Add(baseUnit, value);
            }
    
        }
    
        abstract class PhysicalQuantities : ISIConversionSubscriber
        {
            public abstract void Register(Action<string, double> register);
        }
    
        class Length : PhysicalQuantities
        {
            public override void Register(Action<string, double> register)
            {
                // for each derived type register the type specific values in this override
                register("in", 1);
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(SIConversion<Length>.GetFactor("in"));
            }
        }
