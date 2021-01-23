    class Program
        {
            delegate void ComponentEventHandler(params dynamic[] args);
    
            event ComponentEventHandler onTest;
    
            static void Main(string[] args)
            {  
                Program prg = new Program();
    
                // can be bound to event and called that way
                prg.onTest += prg.Test;
                prg.onTest.Invoke("What", 5, 12.0);
    
                Console.ReadKey();
            }
    
            public void Test(params dynamic[] values)
            {
                // assign our params to variables
                string name = values[0];
                int age = values[1];
                double value = values[2];
    
                Console.WriteLine(name);
                Console.WriteLine(age);
                Console.WriteLine(value);
            }
        }
