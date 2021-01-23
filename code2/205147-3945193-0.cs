    namespace TheCompany.Common
    {
        public interface IGenericFormatter
        {
            T Deserialize<T>(Stream serializationStream);
            void Serialize<T>(Stream serializationStream, T graph);
        }
        public class GenericFormatter<F> : IGenericFormatter where F : IFormatter, new()
        {
            private IFormatter _Formatter = new F();
            public T Deserialize<T>(Stream serializationStream) { return (T)_Formatter.Deserialize(serializationStream); }
            public void Serialize<T>(Stream serializationStream, T graphObject) { _Formatter.Serialize(serializationStream, graphObject); }
        }
        public class GenericBinaryFormatter : GenericFormatter<BinaryFormatter> { }
        public class GenericSoapFormatter : GenericFormatter<SoapFormatter> { }
    	
    	public static partial class CSSerialize
        {
            public static T Clone<T>(T source)
            {   
                Debug.Assert(typeof(T).IsSerializable);
                if (!typeof(T).IsSerializable) { throw new SerializationException(ExceptionMessages.ObjectNoSerializable); }
    
                T result;
                IGenericFormatter formatter = new GenericBinaryFormatter();            
                using(MemoryStream stream = new MemoryStream())
                {                
                    formatter.Serialize(stream, source);
                    stream.Seek(0, SeekOrigin.Begin);
                    result = formatter.Deserialize<T>(stream);
                }
                return result;
            }
            public static T CloneXml<T>(T source)
            {
                T result;
                DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                using (MemoryStream memory = new MemoryStream())
                {
                    serializer.WriteObject(memory, source);
                    memory.Position = 0;
                    result = (T)serializer.ReadObject(memory);             
                }
                return result;
            }		
    	}
    }
