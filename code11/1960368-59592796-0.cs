            string ItemString = "Stone";
    		Item enumItem;
    		Item.TryParse(ItemString, out enumItem);
    		int foo = (int)enumItem;
    		Console.WriteLine(foo);
    public enum Item
    {
        Wood,
        Stone
    }
