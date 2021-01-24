    static void Main(string[] args)
    {
        var meny = true;
        var items = File.ReadLines("inventory.txt").ToList();
        while (meny)
        {
            Console.WriteLine(" \tWelcome to the inventory");
            Console.WriteLine("\t[1] Add item");
            Console.WriteLine("\t[2] Show your inventory");
            Console.WriteLine("\t[3] Delete your inventory");
            Console.WriteLine("\t[4] Quit");
            Console.Write("\tChoose: ");
            int menyVal = Convert.ToInt32(Console.ReadLine());
            // switch 
            switch (menyVal)
            {
                case 1:
                    Console.WriteLine("\nAdd item: ");
                    items.Add(Console.ReadLine());
                    break;
                case 2:
                    if (items.Length > 0)
                        Console.WriteLine(String.Join("\n", items));
                    else Console.WriteLine("Nothing in inventory");
                    break;
                case 3:
                    Console.WriteLine("\n\tRemoving items ");
                    items.Clear();
                    break;
                case 4:
                    meny = false;
                    File.WriteAllLines("inventory.txt", items);
                    break;
                default:
                    Console.WriteLine("\nError, Not a valid value, Try again");
                    break;
            }
        }
    }
