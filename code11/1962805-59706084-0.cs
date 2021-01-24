        Console.Write("Year: ");
        int input =Convert.ToInt32(Console.ReadLine());
        while(input>2012 && input<2016)
        {
        if (input >= 2012)
        {
            if (input <= 2016)
            {
                Console.WriteLine(input);
            }
        }
        else
        {
            Console.Write("Year: ");
            Console.ReadLine(); //ask again until becomes true
        }
        }
 
