    //your custom base class
    public abstract class MyObject
    {
        public virtual void MyCustomMethod()
        {
            //Your custom method implementation
        }
        public abstract void MyCustomAbstractMethod();        
        public override string ToString( )
        {
           //your custom implementation for override
        }
    
        public override string Equals( )
        {
            //your custom implementation for override
        }
        
        public override string GetHashCode( )
        {
            //your custom implementation for override
        }
        
        public override string GetType( )
        {
            //your custom implementation for override
        }
    }
    //your custom child class
    public class CustomClass1 : MyObject //still derived from object
    {
        //implement and override the MyObject and object methods
    }
    
    //your custom child class
    public class CustomClass2 : MyObject //still derived from object
    {
        //implement and override the MyObject and object methods
    }
