    #define Release 
    using System;
    class Program
    {  
    #if Release==true
        public static void Main(string[] args) //for enemy
        {     
            Console.WriteLine("go to  hell");
            Console.ReadLine();
        }
        
    #elif Release==false
        static void Main(string[] args) //for friend
        {    
            
             Console.WriteLine("hello ");
            
            Console.ReadLine();
        }
    #endif 
    }
