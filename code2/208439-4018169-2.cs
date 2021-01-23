    public abstract class MyBaseClass
    {
        public MyClass()
        {
            //constructor code
        }
        protected void Copy(MyBaseClass classToCopy)
        {
            //copy code
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
            base.Copy(myClassToCopy);
            //specific copy code for this extensions in this class
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
            base.Copy(myClassToCopy);
            //specific copy code for this extensions in this class
        } 
    }
