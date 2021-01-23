     class Base
                {
                    public Base()
                    {
                        Console.WriteLine("Base");
                    }
                    
                }
                class Derived : Base
                {
                    public Derived()
                    {
                        Console.WriteLine("Derived");
                    }
                }
    
     class Program
            {
                static void Main()
                {
                    Derived d = new Derived();
                }
    
            }
