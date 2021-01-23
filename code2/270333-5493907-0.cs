    public abstract class MyBaseClass<T> where T : new()
    {
        protected MyBaseClass()
        {
            T myObj = new T();
             // Instantiate object of type passed in 
             /* This is the part I'm trying to figure out */
        }
    }
    
    public class MyDerivedClass : MyBaseClass<Whatever>
    {
        public MyDerivedClass() 
        {
        }
    }
