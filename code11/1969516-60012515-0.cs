    class Program
    {
        public static List<string> inventory = new List<string>();
        public static void printInventory()
        {
            Console.WriteLine("===Your Inventory===");
            foreach(var item in Enumerable.Range(0,inventory.Count))
            {
                Console.WriteLine(item+": "+inventory[item]);
            }
        }
        static void Main(string[] args)
        {
            var meny = true;
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
                        inventory.Add(Console.ReadLine());
                        break;
                    case 2:
                        printInventory();
                        break;
                    case 3:
                        printInventory();
                        Console.WriteLine("\nSelect what Item you want to delete");
                        int entry = int.Parse(Console.ReadLine());
                        inventory.RemoveAt(entry);
                        break;
                    case 4:
                        meny = false;
                        break;
                    default:
                        Console.WriteLine("\nError, Not a valid value, Try again");
                        break;
                }
            }
            Console.ReadLine();
        }
    }
