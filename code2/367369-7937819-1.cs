    // Put all the methods here
    public class MyClass
    {
        protected List<SomeSuperType> myList = new List<SomeSuperType>();
        protected MyClass()
        {
        }
    }
    // This class will define only the generic constructor
    public class MyClass<T> : MyClass where T : SomeSuperType
    {
        public MyClass(ICollection<T> elements)
        {
            foreach (SomeSuperType element in elements)
            {
                myList.Add(element);
            }
        }
    }
