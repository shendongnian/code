    class DerivedClass2 : BaseClass
    {
        GenericClass<DerivedClass1> subItem;
    
        public DerivedClass2()
        {
            subItem = new GenericClass<DerivedClass1>();
        }
    }
