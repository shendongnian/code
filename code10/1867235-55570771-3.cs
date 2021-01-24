            Console.Write("Enter the amount of Money!: P");
            moneyAvailable = int.Parse(Console.ReadLine());
            switch (userChoice)
            {
                case "1":
                    itemPrice = itemPrice + soda;
                    break;
                case "2":
                    itemPrice = itemPrice + juice;
                    break;
                case "3":
                    itemPrice = itemPrice + water;
                    break;
                default:
                    Console.WriteLine("Invalid. Choose 1, 2 or 3.");
                    break;
            }
           if (itemPrice < soda)
            {
                Console.WriteLine($"Inserted so far: P0 out of P{itemPrice}");
            }
