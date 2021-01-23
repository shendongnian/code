public class Item
{
  public string item_code;
  public int qty;
  public Item(string i, int q)
  {
    this.item_code = i;
    this.qty = q;
  }
}
public class Invoice
{
  public List<Item> Items { get; private set; }
 
  public Invoice()
  {
    this.Items = new List<Item>();
  }
}
public class TestInvoice
{
  public void Test()
  {
    Invoice inv = new Invoice();
    inv.Items.Add(new Item("apple", 10));
    List<Item> my_items = new List<Item>();
    my_items.Add(new Item("apple", 10));
    inv.Items = my_items;   // compilation error here.
  }
}
