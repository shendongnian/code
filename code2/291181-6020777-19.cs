    interface ISIConversionSubscriber {
        void Register();
    }
    
    static class SIConversion<T> where T : ISIConversionSubscriber, new()
    {
    
        private static Dictionary<string, double> myConvertableUnits = new Dictionary<string,double>();
    
        public static double GetFactor(string baseUnit)
        {
            if (myConvertableUnits.Count == 0)
            {
                T quantityConsumer = new T();
                quantityConsumer.Register();
            }
    
            return myConvertableUnits[baseUnit];
    
        }
    
        public static void RegisterConversionFactor(string baseUnit, double value)
        { 
            // if not exists
            myConvertableUnits.Add(baseUnit, value);
            // implement the rest by yourself
        }       
    
    }
    
    abstract class PhysicalQuantities : ISIConversionSubscriber
    {
        public abstract void Register();
    }
    
    class Length : PhysicalQuantities {
        public override void Register()
        {
            // for each type register the type specific values
            SIConversion<Length>.RegisterConversionFactor("in", 1);
        }
    }
