    public class ClassA
    {
        public void ClassAMethod()
        {
        }
    }
    public class ClassB
    {
        
        public void ClassBMethod()
        {
            ClassA classAInstance = new ClassA();
            classAInstance.ClassAMethod();
        }
    }
