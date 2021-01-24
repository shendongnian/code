if (!lstOrderPad.Items.Contains(item.Name))
This will always be true if None of the items/string contain exact item.Name. Every item of yours is a "{x,y},{a,b}"... never JUST "x".
if you change the query to below, you will check every item in the list of items to see if the name is part of it.
var itemWithSameName = lstOrderPad.Items.Where(x = x.Contains(item.Name)).FirstOrDefault();
Now you can check if the itemWithSameName is null or not to replace it. BUT, you store each of the elements as a string. Not sure how you plan to determine which part of the string is quantity that you will update. You should definitely look into a class that can help you store these values. 
Something like...
public class Order
{
    public Order ()
    {
        Items = new List<Item>();
    }
    public List<Item> Items { get; set; }
}
public class Item
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public int Price { get; set; }
}
This gives you more flexibility in queries and updates to items. Hope it helps.
