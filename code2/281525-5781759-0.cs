    class Program
        {
           private static T New<T>(out T item) where T : new()
           {
               item = new T();
    
               return item;
           }
    
           static Dictionary<Int32, Int32> _member = New(out _member);
    
           static void Main(string[] args)
           {
               Dictionary<Int32, Int32> local = New(out local);
           }
    }
