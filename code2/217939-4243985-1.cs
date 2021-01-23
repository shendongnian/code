    abstract class Base
    {
        protected List<string> MyList = new List<string>();
        
        protected abstract IEnumerable<string> GetItems();
        
        protected void FillMyList()
        {
            MyList.AddRange(GetItems());
        }
    }
    
    class Derived : Base
    {
        protected override IEnumerable<string> GetItems()
        {
            yield return "test";
            yield return "test2";
        }
    }
