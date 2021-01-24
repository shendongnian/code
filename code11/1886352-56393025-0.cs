class MyItem{
    public string Name { get; set; }
    public int Price { get; set; }
}
Then at the start of the class with the AskForTheItems method and probably also the main method, you need to add a List to store the items. You'd do that like this:  
private static List<MyItem> items = new List<MyItem>();
For the method which gets the items, you'll need to some adjustments.  
private static void AskForTheItems()
{
    do
    {
        Console.WriteLine("Add your item:");
        // get the name
        Console.Write("Name: ");
        string name = Console.ReadLine();
        // get and convert the price
        Console.Write("Price: ");
        int price = int.Parse(Console.ReadLine());
        // create the item and fill it with the values
        MyItem item = new MyItem();
        item.Name = name;
        item.Price = price;
        // add the item to your list
        items.Add(item);
        // ask if the user want's to add another one
        Console.WriteLine("Again? (y/n)");
    }
    while (Console.ReadKey(true).Key != ConsoleKey.N);
}
Printing the cheapest and most expensive one is fairly easy using Linq (there might even be an easier/better way).
private static void PrintCheapestAndMostExpensive() {
    // get the first item where the price is the same as the minimum of all prices in the list
    MyItem cheapestItem = items.First(i => i.Price == items.Min(i2 => i2.Price));
    // get the first item where the price is the same as the maximum of all prices in the list
    MyItem mostExpensiveItem = items.First(i => i.Price == items.Max(i2 => i2.Price));
    Console.WriteLine($"The cheapest item is: {cheapestItem.Name} and the most expensive item is: {mostExpensiveItem.Name}");
}
I hope this helps. If you have any questions, feel free to ask - I'll try to explain anything you don't understand yet.
