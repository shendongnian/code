        public T CastDBValue<T>(object value)
        {
            return MapValue<T>(value);
        }   
        internal static T MapValue<T>(object value)
        {
            try
            {
                T result;
                result = value == DBNull.Value ? default(T) : (T)value;
                return result;
            }
            catch (InvalidCastException cex)
            {
                logger.ErrorFormat("Invalid cast while mapping db value '{0}' to type {1}. Error: {2}", value, typeof(T).Name, cex);
                throw new InvalidCastException(string.Format("Invalid cast while mapping db value '{0}' to type {1}. Error: {2}", value, typeof(T).Name, cex.Message));
            }
        }
