I had nothing to do at home, so I made this program for you. It utilizes a [TreeNode][1] data structure. The TreeNode data structure makes it possible to have an "unlimited" amount of sub categories/products. It is also easy to traverse it by setting the node menu to its parent or selected child. You need to add/change products to the Populate() method and maybe change the MenuItem properties to your choice (i.e. Price of Product is of type int).
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    public class Program
    {
        private static List<Product> _cart = new List<Product>();
        static void Main()
        {
            var menu = Populate();
            Run(menu);
            ShowCart();
            ClickToContinue("\n\nGoodbye");
        }
        private static void ClickToContinue(string message)
        {
            Console.WriteLine($"{message}");
            Console.ReadLine();
        }
        private static void ShowCart()
        {
            Console.WriteLine($"Your cart:");
            for (int i = 0; i < _cart.Count; i++)
            {
                Console.WriteLine(String.Format("{0,-4} | {1,-15} | {2,5}", (i + 1).ToString(), _cart[i].Name, _cart[i].Price));
            }
            Console.WriteLine(String.Format("{0,-4} | {1,-15} | {2,5}", "Tot:", $"{_cart.Count()} items", _cart.Sum(item => item.Price).ToString()));
        }
        private static void PrintMenu(TreeNode<MenuItem> menu, string title)
        {
            title = string.IsNullOrEmpty(title) ? string.Empty : $"> {title.Trim()}";
            var menuTitle = $"{menu.Value.Id}. {menu.Value.Name}".Trim();
            if (menu.Parent == null)
            {
                Console.WriteLine($"{menuTitle} {title}\n");
                return;
            }
            PrintMenu(menu.Parent, $"{menuTitle} {title}");
        }
        private static void Run(TreeNode<MenuItem> menu)
        {
            while (true)
            {
                Console.Clear();
                PrintMenu(menu, string.Empty);
                var selectedItem = SelectMenuItem(menu);
                switch (selectedItem.Value)
                {
                    case Category _:
                        menu = selectedItem;
                        break;
                    case Product p:
                        Console.WriteLine($"\nYou added {p.Name} to the cart.\n");
                        _cart.Add(p);
                        if (selectedItem.Parent != null)
                            menu = selectedItem.Parent;
                        ClickToContinue("\n\nPress any key to continue");
                        break;
                    case Cart _:
                        Console.WriteLine();
                        ShowCart();
                        if (selectedItem.Parent != null)
                            menu = selectedItem.Parent;
                        ClickToContinue("\n\nPress any key to continue");
                        break;
                    case GoBack b:
                        Console.WriteLine();
                        if (b.IsExit)
                            return;
                        menu = (selectedItem.Parent?.Parent != null) ? selectedItem.Parent.Parent : selectedItem.Parent;
                        break;
                    default:
                        throw new Exception($"{selectedItem.Value} not implemented");
                    case null:
                        throw new ArgumentNullException(nameof(selectedItem.Value));
                }
            }
        }
        private static TreeNode<MenuItem> SelectMenuItem(TreeNode<MenuItem> menuItem)
        {
            var minValue = menuItem.Children.OrderBy(i => i.Value.Id).FirstOrDefault().Value.Id;
            var maxValue = menuItem.Children.OrderBy(i => i.Value.Id).LastOrDefault().Value.Id;
            Console.WriteLine($"Please select an option between {minValue} and {maxValue}: ");
            foreach (var child in menuItem.Children)
            {
                var price = child.Value is Product ? $"{(child.Value as Product).Price}" : string.Empty;
                Console.WriteLine(String.Format("{0,-4} | {1,-15} | {2,5}", child.Value.Id.ToString(), child.Value.Name, price));
            }
            var selectedId = TryParseInput();
            while (true)
            {
                var selectedItem = menuItem.Children.FirstOrDefault(m => m.Value.Id == selectedId);
                if (selectedItem != null)
                {
                    return selectedItem;
                }
                //Selected id does not exist in the menu
                Console.WriteLine($"Please choose from one of the options.");
                selectedId = TryParseInput();
            }
        }
        private static TreeNode<MenuItem> Populate()
        {
            var menu = new TreeNode<MenuItem>(new Category(1, "Menu"));
            var sweets = new TreeNode<MenuItem>(new Category(1, "Sweets"));
            sweets.AddChildren(new List<MenuItem> {
                new Product(1, "Chocolate R10", 15),
                new Product(2, "Winegums R12", 20),
                new Product(3, "Astros R15", 11),
                new GoBack(9, "Back"),
            });
            var meats = new TreeNode<MenuItem>(new Category(2, "Meats"));
            meats.AddChildren(new List<MenuItem> {
                new Product(1, "Chicken", 13),
                new Product(2, "Beef", 14),
                new Product(3, "Seafood", 17),
                new GoBack(9, "Back"),
            });
            var produce = new TreeNode<MenuItem>(new Category(3, "Produce"));
            produce.AddChildren(new List<MenuItem> {
                new Product(1, "Apple", 17),
                new Product(2, "Tomato", 25),
                new Product(3, "Orange", 24),
                new GoBack(9, "Back"),
            });
            var cart = new TreeNode<MenuItem>(new Cart(4, "Cart"));
            var exit = new TreeNode<MenuItem>(new GoBack(5, "Exit", true));
            menu.AddChildren(new List<TreeNode<MenuItem>> {
                sweets,
                meats,
                produce,
                cart,
                exit,
            });
            return menu;
        }
        private static int TryParseInput()
        {
            int returnInt;
            while (!int.TryParse(Console.ReadLine(), out returnInt))
            {
                //Cannot parse input as an integer
                Console.WriteLine($"Selection is not a number. Please try again.");
            }
            return returnInt;
        }
    }
    public abstract class MenuItem
    {
        public MenuItem(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
    }
    public class GoBack : MenuItem
    {
        public GoBack(int id, string name, bool isExit = false) : base(id, name) 
        {
            IsExit = isExit;
        }
        public bool IsExit { get; set; }
    }
    public class Cart : MenuItem
    {
        public Cart(int id, string name) : base(id, name) { }
    }
    public class Category : MenuItem
    {
        public Category(int id, string name) : base(id, name) {}
    }
    public class Product : MenuItem
    {
        public Product(int id, string name, int price) : base(id, name)
        {
            Price = price;
        }
        public int Price { get; private set; }
    }
    public class TreeNode<T>
    {
        private readonly T _value;
        private readonly List<TreeNode<T>> _children = new List<TreeNode<T>>();
        public TreeNode(T value)
        {
            _value = value;
        }
        public TreeNode<T> this[int i] => _children[i];
        public TreeNode<T> Parent { get; private set; }
        public T Value { get { return _value; } }
        public ReadOnlyCollection<TreeNode<T>> Children
        {
            get { return _children.AsReadOnly(); }
        }
        public TreeNode<T> AddChild(T value)
        {
            var node = new TreeNode<T>(value) { Parent = this };
            _children.Add(node);
            return node;
        }
        public TreeNode<T> AddChild(TreeNode<T> node)
        {
            node.Parent = this;
            _children.Add(node);
            return node;
        }
        public ReadOnlyCollection<TreeNode<T>> AddChildren(List<T> nodes)
        {
            foreach (var node in nodes)
            {
                AddChild(node);
            }
            return Children;
        }
        public ReadOnlyCollection<TreeNode<T>> AddChildren(List<TreeNode<T>> nodes)
        {
            foreach (var node in nodes)
            {
                AddChild(node);
            }
            return Children;
        }
    }
