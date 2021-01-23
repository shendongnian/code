    public class MemoryUtils
    {
        /// <summary>
        /// Creates a deep copy of a given object instance
        /// </summary>
        /// <typeparam name="TObject">Type of a given object</typeparam>
        /// <param name="instance">Object to be cloned</param>
        /// <returns>Returns a deep copy of a given object</returns>
        /// <remarks>Uses BInarySerialization to create a true deep copy</remarks>
        public static TObject DeepCopy<TObject>(TObject instance)
            where TObject : class
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            TObject clonedInstance = default(TObject);
    
            try
            {
                using (var stream = new MemoryStream())
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(stream, instance);
    
                    // reset position to the beginning of the stream so
                    // deserialize would be able to deserialize an object instance
                    stream.Position = 0;
    
                    clonedInstance = (TObject)binaryFormatter.Deserialize(stream);
                }
            }
            catch (Exception exception)
            {
                string errorMessage = String.Format(CultureInfo.CurrentCulture,
                                "Exception Type: {0}, Message: {1}{2}",
                                exception.GetType(),
                                exception.Message,
                                exception.InnerException == null ? String.Empty :
                                String.Format(CultureInfo.CurrentCulture,
                                            " InnerException Type: {0}, Message: {1}",
                                            exception.InnerException.GetType(),
                                            exception.InnerException.Message));
                Debug.WriteLine(errorMessage);
                throw;
            }
    
            return clonedInstance;
        }
    }
