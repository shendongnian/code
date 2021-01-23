    class PersonCollection : KeyedCollection<string, Person>
    {
        protected override string GetKeyForItem(Person item)
        {
            return item.Name;
        }
    }
