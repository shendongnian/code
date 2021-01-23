    public class SubClass 
    {
       public string word;
       public int number;
    }
    
    public class Base 
    {
        protected SubClass subClassInstance = new SubClass();
    
        protected void SomeMethod()
        {
            this.subClassInstance.word //this is where I'm struggling
        }
    }
