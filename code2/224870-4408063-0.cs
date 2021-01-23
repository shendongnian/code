    public class MyClass
    {
        public string MyProperty1 { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            // You need an instance of a class 
            // before being able to set property values            
            var myClass = new MyClass();
            string propertyName = "MyProperty1";
            // obtain the corresponding property info given a property name
            var propertyInfo = myClass.GetType().GetProperty(propertyName);
            if (propertyInfo != null)
            {
                propertyInfo.SetValue(myClass, "test", null);
                // At this point you've set the value of the MyProperty1 to test 
                // on the myClass instance
                Console.WriteLine(myClass.MyProperty1);
            }
        }
    }
