    public class MyClass
    {
        public MyClass()
        {
            // Set the private property.
            this.Name = "Sample Name from Inside";
        }
    	 public MyClass(string name)
        {
            // Set the private property.
            this.Name = name;
        }
        string _name;
        public string Name
        {
            get
            {
                return this._name;
            }
            private set
            {
                // Can only be called in this class.
                this._name = value;
            }
        }
    }
    
    class Program
    {
        static void Main()
        {
            MyClass mc = new MyClass();
            Console.WriteLine(mc.name);
    		
    		MyClass mc2 = new MyClass("Sample Name from Outside");
            Console.WriteLine(mc2.name);
        }
    }
