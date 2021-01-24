    public class Program
    {
        public static void Main(string[] args)
        {
           
            var genericType = typeof(int); // You could have a string and Type.GetType here
            var genericClassType = typeof(GenericClass<>).MakeGenericType(genericType);
            var instance = (ICanTellYouMyType)Activator.CreateInstance(genericClassType);
            Console.WriteLine(instance.WhatsMyGenericType()); 
            // Output is "Int32"
            
        }
    }
    
    public interface ICanTellYouMyType
    {
        string WhatsMyGenericType();
    }
    
    public class GenericClass<T> : ICanTellYouMyType
    {
        public string WhatsMyGenericType()
        {
            return typeof(T).Name;
        }
    }
