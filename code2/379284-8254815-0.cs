    public class GenericClass<T>()
    {
        ICommonInterface TheObject;
      
        public GenericClass(T theObject)
        {
             TheObject = theObject;
        }
        public string GetName()
        {
            return TheObject.Name;
        }
    }
