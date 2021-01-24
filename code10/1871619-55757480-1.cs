    using System;
    
    enum Color
    {
        Red, Green, Blue
    }
    
    sealed class Program
    {
        static void Main(string[] args)
        {
            Color c = Color.Red;
            
            switch (c)
            {
                case Color.Red:
                    Console.WriteLine("Red");
                    break;
                case Color.Green:
                    Console.WriteLine("Green");
                    break;
    //            case Color.Blue:
    //                Console.WriteLine("Blue");
    //                break;
                default:
                    Console.WriteLine("Undefined color");
                    break;
            }
        }
    }
