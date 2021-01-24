    public class currentlyplaying
    {
        public class Item
        {
            public string name { get; set; }
        }
        public Item item;
    } 
Then you can easily use it like
`    instance.item.name;
`
In my opinion, though, the definition of Item class should not be inside of currentlyplaying class.
