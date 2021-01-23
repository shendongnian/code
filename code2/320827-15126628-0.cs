    private static void ProcessItems(ItemCollection c) {}
    ProcessItems(new Item());
    // ...
    class Item {}
    class ItemCollection : List<Item>
    {
        public static implicit operator ItemCollection(Item item)
        {
            return new ItemCollection {item};
        }
    }
