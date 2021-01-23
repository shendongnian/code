    public class MyBaseClass
    {
        public MyClass()
        {
            //constructor code
        }
        // other methods that all inherited classes can use
    }
    
    public class MyClass: MyBaseClass
    {
        public MyClass():base()
        {
            //constructor code
        }
        public void Copy(MyClass myClassToCopy)
        {
            //copy code
        } 
    }
    
    public class InheritedClass : MyBaseClass
    {
        public InheritedClass():base()
        {
            //constructor code
        }
        public void Copy(InheritedClass inheritedClassToCopy)
        {
            //copy code
        } 
    }
