    public class MyClass
    {
        public virtual int MyMethod() => 42;
        public virtual int MyMethod1() => 1;
        public virtual int MyMethod2() => 2;
        public virtual int MyMethod3() => 3;
    }
        
    [Fact]
    public void Sample() {
        var sub = Substitute.For<MyClass>();
        sub.When(x => x.MyMethod()).CallBase();            
        // Returns from base:
        Assert.Equal(42, sub.MyMethod());
        // Other methods mocked (return default value for int):
        Assert.Equal(0, sub.MyMethod1());
        Assert.Equal(0, sub.MyMethod2());
        Assert.Equal(0, sub.MyMethod3());
    }
