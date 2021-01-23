    class FoodItem
    {
         public int Position { get; set; }
         public string Name { get; set; }
    }
    List<FoodItem> list = new List<FoodItem>
    {
         new FoodItem { Position = 1, Name = "apple" },
         new FoodItem { Position = 2, Name = "kiwi" }
    };
