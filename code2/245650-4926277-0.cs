    class Program
    {
        static void Main(string[] args)
        {
          
            Console.WriteLine("Please input your cent or dollar");
            int coins = int.Parse(Console.ReadLine());
                 
            int[] dollars = new int[2];
           
             dollars[0] = coins / 100;
             dollars[1] = coins % 100;
            
            Console.WriteLine("{0} dollar and {1} coins", dollars[0], dollars[1]);
            Console.ReadLine();
         
           
         
            
        }
