    class QuantityConversion {
    
        protected static Dictionary<Type,Dictionary<string, double>> myConvertableUnits = new Dictionary<Type,Dictionary<string,double>>();
    
        public static double GetConversionFactorToSI<T>(string baseUnit) where T : PhysicalQuantities, new()
        {
            if (!myConvertableUnits.ContainsKey(typeof(T)))
            {
               // we need an instance to register so create a temp one
               T quantityConsumer = new T();
               quantityConsumer.RegisterQuantities();
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
        public void RegisterQuantities()
        {
            QuantityConversion.RegisterConversionFactor(this.GetType(), "in", 1);
        }
    }
    
    class PhysicalQuantities : QuantityConversion
    {
      // whatever you need
    }
    
    class Length : PhysicalQuantities {
    
    }
