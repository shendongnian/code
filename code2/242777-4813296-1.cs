    public class Category
    {
        public IEnumerable<InnerItem> InnerList
        {
            get{/*...*/}
        }
    }
    
    class InnerItem
    {
        public string Name
        {
            get{/*...*/}
        }
    }
    public class SampleModel
    {
        public IEnumerable<Category> Categories
        {
            get {/*...*/}
        }
    }  
