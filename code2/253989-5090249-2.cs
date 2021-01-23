    abstract class DataManager<TValue>
    {
        protected static Dictionary<string, TValue> Values=new Dictionary<string, TValue>();
    }
    
    class TextManager : DataManager<string>
    {
        static TextManager()
        {
            Values.Add("test","test");
        }
        
        public static string test()
        {
            return Values["test"];
        }
    }
    
    class IntManager : DataManager<int>
    {
        static IntManager()
        {
            Values.Add("test",1);
        }
    
        public static int test()
        {
            return Values["test"];
        }   
    }
    
    public static void Main (string[] args)
    {
        Console.WriteLine(IntManager.test());    
        Console.WriteLine(TextManager.test());    
    }
