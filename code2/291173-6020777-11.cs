        interface ISIConversionSubscriber
        {
            void Register();
        }
    
        sealed class SIConversion {
    
            private static Dictionary<Type,Dictionary<string, double>> myConvertableUnits = new Dictionary<Type,Dictionary<string,double>>();
    
            public static double GetFactor<T>(string baseUnit) where T : ISIConversionSubscriber, new()
            {
                if (!myConvertableUnits.ContainsKey(typeof(T)))
                {
                    T quantitySubscriber = new T();
                    quantitySubscriber.Register();
                }
    
                return myConvertableUnits[typeof(T)][baseUnit];
    
            }
    
            public static void RegisterConversionFactor(Type type, string baseUnit, double value)
            { 
                // if not exists
                var quantityConvertion = new Dictionary<string, double>();
                quantityConvertion.Add(baseUnit, value);
                myConvertableUnits.Add(type, quantityConvertion);
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
                SIConversion.RegisterConversionFactor(this.GetType(), "in", 1);
            }
        }
