    public class BaseClass<T> where T: BaseItem
    {
        public List<T> items;
        protected BaseClass()
        {
            // some code to build list of items
        }
    }
    
    public class DerivedClass: BaseClass<DerivedItem>
