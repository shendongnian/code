     static void Main(string[] args)
        {
            int i = 1;
            Console.WriteLine("Do while loop positive numbers");
    
            do
            {
                
                Console.WriteLine("Pass {0} in the loop", i++);
                //if your number is divisible by 5 then display message 
            } while (i <= 20);
    
            Console.ReadLine();
        }
