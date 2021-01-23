    public interface MyInterface
    {
        void Copy(MyClass classToCopy)
    }
    
    public class MyClass : MyInterface
    {
        void MyInterface.Copy(MyClass classToCopy)
        {
            //copy code
        } 
    }
