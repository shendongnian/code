    using System;
    
    class Test
    {
        public string Text { get; set; }
        
        static void Main()
        {
            Test t = new Test();
            
            string x = t.Text = "Hello";
            Console.WriteLine(x); // Prints Hello
        }
    }
