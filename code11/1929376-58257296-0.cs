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
            List<VendingItem> stockCatalog = CatalogueData();
            // Show the catalog to the user
            stockCatalog.ForEach(i => {
                Console.WriteLine($"Snack: {i.name}, Code: {i.code}, Price: £{i.price}");
            });
            // Get an item selection from the user
            VendingItem selection = GetSelection(stockCatalog);
            // Get a quantity from the user
            Console.WriteLine("How many of this item would you like?");
            int numOfItem = int.Parse(Console.ReadLine());
            double totalValue = selection.price * numOfItem;
            Console.WriteLine($"Your total cost is {totalValue}.");
        
            Console.ReadLine();
        }
        // Get a selection from the user, if the user selection doesn't match an item in the catalog, ask again until it does.
        static VendingItem GetSelection(List<VendingItem> vendingItems)
        {
            Console.WriteLine("Please enter the code that corresponds with the item you would like: ");
            string itemCode = Console.ReadLine();
            if (vendingItems.Select(i => i.code).Contains(itemCode))
            {
                return vendingItems.First(i => i.code == itemCode);
            }
            else
            {
                Console.WriteLine("That is not an item in the list.");
                return GetSelection(vendingItems);
            }
        }
        public static List<VendingItem> CatalogueData()
        {
            List<VendingItem> vendingItems = new List<VendingItem>();
            // Add food items
            vendingItems.Add(new VendingItem { code = "A1", price = 1.30, name = "Mars Bar" });
            vendingItems.Add(new VendingItem { code = "A2", price = 1.30, name = "Milky Way" });
            vendingItems.Add(new VendingItem { code = "A3", price = 1.30, name = "Double Decker" });
            vendingItems.Add(new VendingItem { code = "A4", price = 1.30, name = "Kit Kat" });
            vendingItems.Add(new VendingItem { code = "A5", price = 1.30, name = "Dairy Milk" });
            vendingItems.Add(new VendingItem { code = "A6", price = 1.70, name = "Pringles Original" });
            vendingItems.Add(new VendingItem { code = "A7", price = 1.70, name = "Pringles Salt and Vinegar" });
            vendingItems.Add(new VendingItem { code = "A8", price = 1.70, name = "Pringles Cheese and Onion" });
            vendingItems.Add(new VendingItem { code = "A9", price = 1.70, name = "Pringles Texas BBQ" });
            vendingItems.Add(new VendingItem { code = "A10", price = 1.70, name = "Pringles Prawn Cocktail" });
            // Add drink items
            vendingItems.Add(new VendingItem() { code = "A11", price = 1.00, name = "Water" });
            vendingItems.Add(new VendingItem() { code = "A12", price = 1.35, name = "Red Bull" });
            vendingItems.Add(new VendingItem() { code = "A13", price = 1.35, name = "Monster" });
            vendingItems.Add(new VendingItem() { code = "A14", price = 1.20, name = "Fanta Orange" });
            vendingItems.Add(new VendingItem() { code = "A15", price = 1.20, name = "Fanta Fruit Twist" });
            // Send back the catalog collection
            return vendingItems;
        }
    }
