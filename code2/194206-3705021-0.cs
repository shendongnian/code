    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            int lap, avg = 0;
    
            Random generator = new Random();
       
            double time = generator.Next(5, 10);
            double totalTime = 0.0;
    
            for (lap = 1; lap <= 10; lap++) 
            {
                time = (generator.NextDouble())* 10 + 1;
                Console.WriteLine("Lap {0} with a lap time of {1:##.00} seconds!!!!", 
                    lap, time);  
      
                totalTime += time;
            }
    
            Console.WriteLine("The total time it took is {0}", totalTime);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Slap the enter key to continue");
            Console.ReadLine();
        }
    }
    
