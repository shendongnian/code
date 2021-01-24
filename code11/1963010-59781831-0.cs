    public class ClassA
    {
        //some code here
    }
    public class ClassB
    {
        //some code here
    }
    public class ClassC
    {
        //some code here
    }
    public class ViewModelA
    {
        private ClassC typeC;
        // this is a constructor injection - yes, it's that simple.
        public ViewModelA(ClassC _typeC)
        {
            typeC = _typeC;
        }
        public void Method()
        {
            typeC.doStuff();
        }
    }
    public class ViewModelB
    {
        private ClassA typeA;
        private ClassB typeB;
        public ViewModelB(ClassA _typeA, ClassB _typeB)
        {
            typeA = _typeA;
            typeB = _typeB;
        }
        public void Method()
        {
            typeA.doStuff();
            typeB.doAnotherStuff();
        }
    }
