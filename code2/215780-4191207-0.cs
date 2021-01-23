    public SelectList Categories
    {
        get
        {
            var categories = Database.GetCategories(); // made-up method
            return new SelectList(categories, "Key", "Value");
        }
    }
