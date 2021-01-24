@page "/"
<h1>Hello, world!</h1>
@foreach (var item in this.MenuItems)
{          
<li>
    <a class="@item.Class" 
       @onclick="@(() => this.ToggleItemClass(item))">@item.Name @item.Class
    </a>
</li>
}
@code {
    public class Item
    {
        public string Class {set; get;} = "blue";
        public string Name {set; get;} = "Item";
    }
    public List<Item> MenuItems = new List<Item>()
    {
        new Item(),
        new Item(),
        new Item(),
    };
    // Toggle method
    void ToggleItemClass(Item item)
    {
        item.Class = item.Class == "red" ? "green" : "red";
    }
}
  [1]: https://i.stack.imgur.com/LudFa.gif
  [2]: https://blazorfiddle.com/s/ell2z9s2
