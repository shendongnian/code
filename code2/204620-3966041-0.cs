    public sealed class Test: IDisposable, ICollection<Item>
    {
        public void Initialize()
        {
            var item1 = new Item(); // no warning
            itemCollection.Add(item1);
            var item2 = new Item(); // no warning
            ((ICollection<Item>)this).Add(item2);
            var item3 = new Item(); // no warning
            AddSomething(item3);
        }
    
        //... implement ICollection and Method AddSomething
    }
