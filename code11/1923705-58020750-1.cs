    public class Form
    {
        private double value1 = 5;
        public double Value1 { 
            get {
                Console.WriteLine("Getting Value")
                return value1;
            }
            set {
                Console.WriteLine("Setting Value")
                value1 = value;
            }
        }
    }
---
    var myForm = new Form();
    // calls Form.Value1.Get
    // prints "Getting Value"
    // prints "5.0"
    Console.WriteLine(myForm.Value1) 
    
    // calls Form.Value1.Set
    // prints "Setting Value"
    myForm.Value1 = 10.5;
    // calls Form.Value1.Get
    // prints "Getting Value"
    // prints "10.5"
    Console.WriteLine(myForm.Value1) 
