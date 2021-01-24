    public class UnitTestClass{
    
    private readonly ClassUnderTest _classUnderTest;
    private readonly Mock<ClassUnderTestDependecy> mockedInstance;
    
    public UnitTestClass {
    mockedInstance= new Mock<ClassUnderTestDependecy>();
    _classUnderTest= new ClassUnderTest (ClassUnderTestDependecy.Object);
    }
    
    }
