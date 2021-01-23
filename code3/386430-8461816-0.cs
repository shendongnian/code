    public class PersonCollection : System.Collections.ObjectModel.KeyedCollection<string, Person>
    {
        protected override string GetKeyForItem(Person item)
        {
            return item.Name;
        }
    }
