    public class myList : List<MyClass>
    {
        public MyClass this[string SearchedName]
        {
            get
            {
                return this.SingleOrDefault(mc => mc.Name == SearchedName);
            }
        }
    }
