            string name = string.Empty, wtd = string.Empty, act = string.Empty, trav = string.Empty;
            int result = 0, ppl = 0;
            bool isTrue = true;
            Console.WriteLine("What is your name?");
            name = Console.ReadLine();
            Console.WriteLine("Hello {0}, What do you want to do today?", name);
            while (isTrue)
            {
                Console.WriteLine("1) Action\n2) Chilling\n3) Danger\n4) Good Food\n");
                var isValidInt = int.TryParse(Console.ReadLine(), out result);
                if(isValidInt)
                {
                    if (result == 1)
                    {
                        wtd = "action";
                        act = "Stock Car Racing";
                        isTrue = false;
                    }
                    else if (result == 2)
                    {
                        wtd = "chilling";
                        act = "Hiking";
                        isTrue = false;
                    }
                    else if (result == 3)
                    {
                        wtd = "danger";
                        act = "Skydiving";
                        isTrue = false;
                    }
                    else if (result == 4)
                    {
                        wtd = "good food";
                        act = "to Taco Bell";
                        isTrue = false;
                    }
                    else
                    {
                        wtd = "";
                        act = "";
                        Console.WriteLine("I do not understand. Please select again");
                    }
                }
                else
                {
                    Console.WriteLine("Use numbers only");
                }
            }
            Console.WriteLine("Okay. If you are in the mood for " + wtd + ", then you should go " + act + "and travel in " + trav + ".");
