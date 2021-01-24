    class Program
    {
        static void Main(string[] args)
        {
            List<Item> items = new List<Item>()
            {
                new Item
                {
                    Name = "Soda",
                    Price = 30
                },
                new Item
                {
                    Name = "Juice",
                    Price = 23
                },
                new Item
                {
                    Name = "Water",
                    Price = 15
                }
            };
            while (true)
            {
                //MENU
                Log("Available Items:");
                for(int i = 0; i < items.Count; i++)
                {
                    Log("{0}. {1} = P{2}", i, items[i].Name, items[i].Price);
                }
                Console.WriteLine();
                bool isInputValid = false;
                string userChoice = string.Empty;
                int chosenIndex = 0;
                while (isInputValid == false)
                {
                    try
                    {
                        Log("Choose your Item:");
                        userChoice = Console.ReadLine();
                        chosenIndex = int.Parse(userChoice);
                        if(chosenIndex < 0 || chosenIndex >= items.Count)
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                        isInputValid = true;
                    }
                    catch
                    {
                        Log("Invalid choice!");
                    }
                }
                Item chosenItem = items[chosenIndex];
                bool isPriceReached = false;
                string userInsertedMoney = string.Empty;
                int insertedMoney = 0;
                while (isPriceReached == false)
                {
                    try
                    {
                        Log("P{0} of P{1} needed Money for {2} inserted, waiting for more...", insertedMoney, chosenItem.Price, chosenItem.Name);
                        userInsertedMoney = Console.ReadLine();
                        insertedMoney += int.Parse(userInsertedMoney);
                        isPriceReached = insertedMoney >= chosenItem.Price;
                    }
                    catch
                    {
                        Log("Invalid money!");
                    }
                }
                Log("Here is your {0} with a rest of {1} money.{2}", chosenItem.Name, insertedMoney - chosenItem.Price, Environment.NewLine);
            }
        }
        private static void Log(string message, params object[] args)
        {
            Console.WriteLine(string.Format(message, args));
        }
    }
    public class Item
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }
