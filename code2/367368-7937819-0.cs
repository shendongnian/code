    public class MyClass
    {
        private List<SomeSuperType> myList = new List<SomeSuperType>();
        public static MyClass MyClassBuilder<T>(ICollection<T> elements) where T : SomeSuperType
        {
            var myClass = new MyClass();
            foreach (SomeSuperType element in elements)
            {
                myClass.myList.Add(element);
            }
            return myClass;
        }
        protected MyClass()
        {
        }
    }
