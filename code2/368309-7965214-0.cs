    public class CreatorOf<T> where T : CreatorOf<T>
    {
        public static T Create()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }
    }
    
    public class Inheritor : CreatorOf<Inheritor>
    {
        public Inheritor()
        {
            
        }
    }
    
    
    public class Client
    {
        
        public Client()
        {
            var obj = Inheritor.Create();
        }
    }
