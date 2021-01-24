    List<Item> items = new List<Item>();
    using (StreamReader sr = new StreamReader("Items.csv"))
    {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            string[] parts = line.Split(',');
            string price = parts[1];
            if (price != "currentPrice")
                items.Add(new Item
                {
                    CurrentPrice = Convert.ToDouble(price),
                    CategoryName = parts[0],
                    CurrencyId = parts[2]
                });
        }
    }
    foreach (Item item in items.OrderBy(i => i.CurrentPrice))
        Console.WriteLine(item.CategoryName + "," +
                          item.CurrentPrice + "," +
                          item.CurrencyId);
    public class Item
    {
        public string CategoryName { get; set; }
        public double CurrentPrice { get; set; }
        public string CurrencyId { get; set; }
    }
