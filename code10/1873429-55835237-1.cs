public class Item
{
    string Name = "Rock";
    string Description = "It's a rock.";
}
public class Inventory
{
    List<string> plyItems = new List<string>();
}
This way you have private variables in your class.  Your way you would have local variable in your class constructors that would cease to exist after the constructors have run their course.
Now if you want to add `Item.Name` to `plyItems` you have a few choices to make.  
**Option 1:**
You can make everything public:
public class Item
{
    public string Name = "Rock";
    public string Description = "It's a rock.";
}
public class Inventory
{
    public List<string> plyItems = new List<string>();
}
and then after you have created an instance of `Item` and an instance of `Inventory` somewhere in code:
Item item = new Item();
Inventory inventory = new Inventory();
you can just add it to the list:
inventory.plyItems.Add(item.Name);
**Option 2:** Make a couple functions:
public class Item
{
    string Name = "Rock";
    string Description = "It's a rock.";
    public string GetName() 
    { 
        return name; 
    }
}
public class Inventory
{
    List<string> plyItems = new List<string>();
    public void AddName(string _name)
    {
        plyItems.Add(_name);
    }
}
Then using the same instances as option 1, call:
inventory.AddName(item.GetName());
