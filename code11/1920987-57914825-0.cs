    //Gives user necessary info to operate vending machine
            Console.WriteLine("Welcome to vending machine.");
            Console.WriteLine("We offer you (s)oda, coo(k)ies, and (c)hips");
            Console.WriteLine("Please select the product you want to purchase:");
            string userselection = Console.ReadLine();
            if (userselection == "s")
            {
                //Generates a random number between 0 and 5 using the random class
                double lottery = new Random().Next(1, 5) * 10;
                Console.WriteLine("Congratulations! You win a coupon with " + lottery + " cents.");
                //soda price after lottery 
                double sodaprice = 100 - lottery;
                Console.WriteLine("You only need to pay " + sodaprice + " cents");
                double coin;
                do
                {
                    Console.WriteLine("Please insert a coin of 5, 10, or 25:");
                    if (double.TryParse(Console.ReadLine(), out coin))
                    {
                        if (coin == 25 || coin == 10 || coin == 5)
                        {
                            sodaprice -= coin;
                            Console.WriteLine(sodaprice > 0 ? "You still owe " + sodaprice + " cents." : "Finish...");
                        }
                    }
                } while (sodaprice > 0);
            }
            Console.ReadLine();
