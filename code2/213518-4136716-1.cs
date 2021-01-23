    public class Foo<T> 
    {
        private List<T> myObjects;
    
        public Foo(Func<string, T> factory))
        {
            myObjects = new List<T>();
            foreach (string s in GetDataStrings())
                myObjects.Add(factory(s));
        }
    }
