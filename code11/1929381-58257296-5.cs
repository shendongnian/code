    public class Program
    {
        public struct VendingItem
        {
            public string name;
            public double price;
            public string code;
        }
        static void Main(string[] args)
        {
            Dictionary<string, VendingItem> stockDictionary = CatalogDataDictionary();
            // Show the catalog to the user
            foreach (KeyValuePair<string, VendingItem> i in stockDictionary)
            {
                Console.WriteLine($"Snack: {i.Value.name}, Code: {i.Value.code}, Price: £{i.Value.price}");
            }
            // Get an item selection from the user
            VendingItem selection = GetSelection(stockDictionary);
            // Get a quantity from the user
            Console.WriteLine("How many of this item would you like?");
            int numOfItem = int.Parse(Console.ReadLine());
            double totalValue = selection.price * numOfItem;
            Console.WriteLine($"Your total cost is {totalValue}.");
        
            Console.ReadLine();
        }
        // Get a selection from the user, if the user selection doesn't match an item in the catalog, ask again until it does.
        static VendingItem GetSelection(Dictionary<string, VendingItem> vendingItems)
        {
            Console.WriteLine("Please enter the code that corresponds with the item you would like: ");
            string itemCode = Console.ReadLine();
            if (vendingItems.Select(i => i.Key).Contains(itemCode))
            {
                return vendingItems.First(i => i.Key == itemCode).Value;
            }
            else
            {
                Console.WriteLine("That is not an item in the list.");
                return GetSelection(vendingItems);
            }
        }
        public static Dictionary<string, VendingItem> CatalogDataDictionary()
        {
            Dictionary<string, VendingItem> keyValuePairs = new Dictionary<string, VendingItem>();
            // Add the food items
            keyValuePairs.Add("A1", new VendingItem() { code = "A1", price = 1.30, name = "Mars Bar" });
            return keyValuePairs;
        }
    }
