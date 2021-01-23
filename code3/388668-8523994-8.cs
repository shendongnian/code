        public static bool? IsIntegerType<T>() where T : IConvertible
        {
            bool? isInt = null;
            try
            {
                T testInstance = Activator.CreateInstance<T>();
                testInstance = (T)Convert.ChangeType(0.1d, typeof(T));
                isInt = testInstance.ToDouble(CultureInfo.InvariantCulture) != .1d;
            }
            catch
            {   
                // T is a non numeric type, or something went wrong with the activator
            }
            return isInt;
        }
    
