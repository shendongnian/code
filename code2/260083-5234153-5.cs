    public class BaseClass<T> where T: BaseItem, new()
    {
        public List<T> items;
        protected BaseClass()
        {
            items = new List<T>();
            T item = new T();
            item.SomePropertyOfBaseItem=something;
            items.Add(item);
        }
    }
    
    public class DerivedClass: BaseClass<DerivedItem>
