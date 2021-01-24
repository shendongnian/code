    //Test
    var someType = Substitute.For<ISomeType>();
    var someParameter = 42;
    var someReturnValue = 1;
    someType.SomeMethod(someParameter).Returns(someReturnValue);
    var sut = new SomeClass(someType); //sut means system under test
    var result = sut.AMethod();
    //This would test positive as you set the return value of SomeMethod to 1 
    //in case it gets called with a value of 42
    Assert.That(result, Is.EqualTo(someReturnValue));
    //Test end
    //This would be the class you want to unit test
    public class SomeClass
    {
        private ISomeType someType;
    
        public SomeClass(ISomeType someType)
        {
            this.someType = someType;
        }
    
        public int AMethod()
        {
            return someType.SomeMethod(42);
        }
    }
