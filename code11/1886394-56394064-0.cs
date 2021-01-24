    do
            {
                Console.WriteLine("1: Coca-cola"); // skriver ut alternativen för flaska
                Console.WriteLine("2: Fanta");
                Console.WriteLine("3: Pepsi");
                Console.WriteLine("4: Beer");
                Console.WriteLine("5: Redbull");
                Console.WriteLine("6: Cider");
                Console.WriteLine("7: Water");
                try
                {
                    soda_input = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Just numbers, my friend");
                    continue;
                }
               
                switch (soda_input) // Skapar en meny, som skriver ut vilken dryck användaren väljer tills backen blir full.
                {
                    case 1:
                        chosenSoda = "Coca-Cola";
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Du valde Coca-Cola");
                        Console.WriteLine("-------------------");
                        break;
                    case 2:
                        chosenSoda = "Fanta";
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Du valde Fanta");
                        Console.WriteLine("-------------------");
                        break;
                    case 3:
                        chosenSoda = "Pepsi";
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Du valde Pepsi");
                        Console.WriteLine("-------------------");
                        break;
                    case 4:
                        chosenSoda = "Öl";
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Du valde Öl");
                        Console.WriteLine("-------------------");
                        break;
                    case 5:
                        chosenSoda = "Redbull";
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Du valde Redbull");
                        Console.WriteLine("-------------------");
                        break;
                    case 6:
                        chosenSoda = "Cider";
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Du valde Cider");
                        Console.WriteLine("-------------------");
                        break;
                    case 7:
                        chosenSoda = "Vatten";
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Du valde Vatten");
                        Console.WriteLine("-------------------");
                        break;
                    default: // om man skriver siffror ovanför 1-7 så skrivs detta ut.
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Siffor mellan 1-7 min vän");
                        Console.WriteLine("-------------------");
                        break;
                }
     if (chosenSoda != null && chosenSoda != "")
                {
                    crate[numberOfBottles] = chosenSoda; // lagrar svaren i min vektor
                numberOfBottles++;
                }
            } while (numberOfBottles != 24);
