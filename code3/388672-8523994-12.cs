        public static bool? IsIntegerType<T>() where T : IConvertible
        {
            bool? isInt = null;
            try
            {
                T testInstance = Activator.CreateInstance<T>();
                testInstance = (T)Convert.ChangeType(0.1d, typeof(T));
                isInt = Math.Round(testInstance.ToDouble(CultureInfo.InvariantCulture),1) != .1d;
                // if you don't round it and T is float you'll get the wrong result
            }
            catch
            {   
                // T is a non numeric type, or something went wrong with the activator
            }
            return isInt;
        }
    
