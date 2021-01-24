    namespace TestApp
    {
      class Program
      {
    
        public class demo
        {
          public int int001 { get; set; }
          public int int002 { get; set; }
          public int int003 { get; set; }
        }
    
        public static void SetValue(object classInstance, string propertyName, int value)
        {
          PropertyInfo propertyInfo = classInstance.GetType().GetProperty(propertyName);
          propertyInfo.SetValue(classInstance, value);
        }
    
        static void Main(string[] args)
        {
    
          using (EventLogSession eventLogSession = new EventLogSession())
          {
            demo x = new demo { int001 = 10 };
            Console.WriteLine(x.int001);
            SetValue(x, "int001", 11);
            Console.WriteLine(x.int001);
          }
        }
      }
    }
