    abstract class SIConversion {
    
        protected static Dictionary<Type,Dictionary<string, double>> myConvertableUnits = new Dictionary<Type,Dictionary<string,double>>();
    
        public static double GetFactor<T>(string baseUnit) where T : PhysicalQuantities, new()
        {
            // if the factory does not contain  values for this type fill it up
            if (!myConvertableUnits.ContainsKey(typeof(T)))
            {
                T quantityConsumer = new T();
                quantityConsumer.Register();
            }
    
            return myConvertableUnits[typeof(T)][baseUnit];
    
        }
    
        public static void RegisterConversionFactor(Type type, string baseUnit, double value) { 
            // if not exists
            var quantityConvertion = new Dictionary<string, double>();
            quantityConvertion.Add(baseUnit, value);
            myConvertableUnits.Add(type, quantityConvertion);
            // implement the rest by yourself
        }
 
        // derived classes will override this
        public abstract void Register();
    }
    
    abstract class PhysicalQuantities : SIConversion
    {
        // your base class methods
    }
    
    class Length : PhysicalQuantities {
        public override void Register()
        {
            // for each type register the type specific values
            // thiss will be more or less copy paste and replace values
            SIConversion.RegisterConversionFactor(this.GetType(), "in", 1);
        }
    }
