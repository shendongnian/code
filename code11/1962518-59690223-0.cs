c#
class MyList<T> : List<T>
{
    //  Add an event that will be triggered after adding an item
    public event Action<T> ItemAdded;
    //  Override the add method
    public new void Add(T obj)
    {
        //  Call the parent add action
        base.Add(obj);
        //  Trigger the event
        ItemAdded?.Invoke(obj);
    }
}
Using this class, you can subscribe as many functions as you want to the event and all the subscribed actions will be invoked when an item is added.
Try the event:
c#
static void Main()
{
    //  Create empty list
    MyList<string> list = new MyList<string>();
    //  Create a dummy action to display the added item
    void AddItemEventHandler(string item) => Console.WriteLine(item);
    //  Subscribe to the event
    list.ItemAdded += AddItemEventHandler;
    //  Add items to trigger the event
    list.Add("Hello");
    list.Add("Hola");
}
Output:
Hello
Hola
