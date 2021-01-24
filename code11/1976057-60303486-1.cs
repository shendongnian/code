     class Class1 
    {
       public class Subclass1  
        {
          public  class Subclass2 : IDisposable
            {
                public string PropertyNameWhichIsBigName { get; set; }
                public void Dispose()
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (Class1.Subclass1.Subclass2 obj = new Class1.Subclass1.Subclass2())
            {
                string propertiesValue = obj.PropertyNameWhichIsBigName;
            }
        }
    }
