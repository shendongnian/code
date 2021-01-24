    var items = new List<Items>();
    var itemName = string.Empty;
    do
    {
        Console.WriteLine("Insert items that you want to buy, when you are finnish, write 'done'");
        Console.Write("Insert a item: ");
        itemName = Console.ReadLine();
        switch (itemName.ToLower())
        {
            case "done":
                break;
            default:
                Console.WriteLine("Write a price:");
                decimal itemPrice = Convert.ToDecimal(Console.ReadLine());
                var item = new Items(itemName, itemPrice);
                items.Add(item);
                break;
        }
    } while (itemName != "done");
    // Here you now have a list of items.  You can loop over that list for further logic, output, etc.
