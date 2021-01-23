    public class Parent
    {
        public Parent()
        {            
        }
        
        public virtual void PostConstructor()
        {
        }
    }
    
    public class Child : Parent
    {
        public override void PostConstructor()
        {
            base.PostConstructor();
    
            // Your code here
        }
    }
    public void FactoryMethod<T>() where T : Parent
    {
        T newobject = new T();
        newobject.PostConstructor();
    }
