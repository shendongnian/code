c#
var item = new Item
{
    Name "Hello "
};
var secondItem = item;
item.Name = "World";
// This will print 'WorldWorld'
Console.WriteLine(item.Name + secondItem.Name);
Sane principle is happening to your list items, just that instead of the separate variable `secondItem` your second (and third, and fourth, ...) item isn't in a variable, but being held by the list.
Specifically to solve your problem, you'll need to create a new object on every iteration of your loops. Like so:
c#
var items = new List<Item>();
Item item;
for (int i = 0; i < 3; i++)
{
    item = new Item
    {
        Name = "A"
    };
    items.Add(item);
}
for (in i = 0; i < 2; i++)
{
    item = new Item
    {
        Name = "B";
    };
    items.Add(item);
}
This code can be reduced to a few lines (6 to be specific), but I left it this long as it is easier to read and more importantly easier to understand like this
