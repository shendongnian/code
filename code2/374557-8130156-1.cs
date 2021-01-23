    using System.Text;
    
    namespace GenericExperiment
    {
        class Program
        {
            static void Main(string[] args)
            {
                XmlContentReaderBase<PlatformObject>.Deserialize();
                Console.ReadKey();
            }
        }
    
        class GameObject : ICloneable
        {
            object ICloneable.Clone()
            {
                Console.WriteLine("I am the base class");
                return null;
            }
        }
    
        class PlatformObject: GameObject, ICloneable
        {
            object ICloneable.Clone()
            {
                Console.WriteLine("I am the derived class");
                return null;
            }
        }
    
        class XmlContentReaderBase<T> where T : GameObject, new()
        {
            static public object Deserialize()
            {
                T obj = new T();
                ((ICloneable)obj).Clone();
                return obj;
            }
        }
        
    }
