    // Leave this the same
    public ICollection<Item> Items { get; set; }
    // Change function signature here:
    // As you mention Item uses the same underlying type, just return an ICollection<T>
    public ICollection<Item> Get(string value); 
    // Ideally here you want to call .Count on the collectoin, not .Count() on 
    // IEnumerable, as this will result in a new Enumerator being created 
    // per loop iteration
    for (var index = 0; index < Items.Count(); index++) 
