    private readonly int MyReadOnlyVariable;
    private readonly ComplexType MyReadOnlyComplexType;
    public MyClass()
    {
        MyReadOnlyVariable = 2;            //valid
        MyReadOnlyComplexType = something; //valid
    }
    public void NotAConstructor()
    {
        MyReadOnlyVariable = 2;                          //invalid
        MyReadOnlyComplexType = somethingElse;           //invalid
        MyReadOnlyComplexType.Something = somethingElse; //valid
    }
