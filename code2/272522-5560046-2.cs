    static void ToppingMenu()
    {
        int toppSelection = 0;
        while (toppSelection != 999)
        {
            Console.Clear();
            Console.WriteLine("Create Pizza Menu");
            string[] toppName = new string[10] { "Cheese ", "Tomato ", "Mushrooms ", "Green Pepper ", "Black Olives ", "Onions ", "Pepperoni ", "Chicken ", "Tuna ", "End Custom Pizza Creation - Previous Menu" };
            int[] toppAmount = new int[9] { 1, 1, 0, 0, 0, 0, 0, 0, 0 };
            Console.WriteLine("{0}                   {1}", toppName[0], toppAmount[0]);    //Cheese
            Console.WriteLine("{0}                   {1}", toppName[1], toppAmount[1]);    //Tomato
            Console.WriteLine("{0}                {1}", toppName[2], toppAmount[2]);       //Mushrooms
            Console.WriteLine("{0}             {1}", toppName[3], toppAmount[3]);          //Green Pepper
            Console.WriteLine("{0}             {1}", toppName[4], toppAmount[4]);          //Black Olives
            Console.WriteLine("{0}                   {1}", toppName[5], toppAmount[5]);    //Onions
            Console.WriteLine("{0}                {1}", toppName[6], toppAmount[6]);       //Pepperonni
            Console.WriteLine("{0}                  {1}", toppName[7], toppAmount[7]);     //Chicken
            Console.WriteLine("{0}                     {1}", toppName[8], toppAmount[8]);  //Tuna
            Console.WriteLine("\n\n\n{0}           ", toppName[9]);                        //Exit to previous menu option
            Console.WriteLine("\n\nTo finish order, please enter '999'");
            Console.Write("\n\nSelection: ");
            
            toppSelection = int.Parse(Console.ReadLine());
            int i = toppSelection - 1;                                  //i is assigned same value as number entered -1,
                                                                        //i-1 fixes the 1-off fault, where 0 = first topping in array but 1 = first topping by user entry
            if (toppAmount[i] > 2)                 //
            {
                Console.Write("Error, invalid amount");
            }
            else if (toppSelection > 0 && toppSelection < 10)
            {
                toppAmount[i]++;
            }
