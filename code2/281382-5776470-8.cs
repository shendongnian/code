    class SomeClass
    {
        public SomeClass(MyClass myClass)
        {
            m_MyClass = myClass;
        }
        public void SomeMethod()
        {
            ...
            m_MyClass.DoSomething();
        }
    }
