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
            // Before trying to set the value ensure that a property with the
            // given name exists by checking for null
            if (propertyInfo != null)
            {
                propertyInfo.SetValue(myClass, "test", null);
                // At this point you've set the value of the MyProperty1 to test 
                // on the myClass instance
                Console.WriteLine(myClass.MyProperty1);
            }
           
        }
    }
