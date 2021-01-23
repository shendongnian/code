    using System;
    
    using System.Collections.Generic;enter code here
    
    using System.Linq;
    
    using System.Text;
    
    using MyFirstWebServiceConsumerApp.MyFirstWebServiceReference;
    
    namespace MyFirstWebServiceConsumerApp
    
    {
    
        class Program
    
        {
    
            static void Main(string[] args)
    
            {
    
                Service1 webService = new Service1();
    
                Console.WriteLine(webService.MyFirstWebMethod("Dhiraj”, “Kumar”));
    
                Console.ReadLine();
    
            }
    
        }
    
    }
