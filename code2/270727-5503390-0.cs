    public static Namespace1.SomeClass Convert(Namespace2.SomeClass someClass) {
        Namespace1.SomeClass rtn = new Namespace1.SomeClass();
        rtn.SomeProp = someClass.SomeProp;
        rtn.SomeOtherProp = someClass.SomeOtherProp;
        return rtn;
    }
