    class Foo<T> { }
    class Bar : Foo<int> { }
    class FooBar : Bar { }
    
    [Fact]
    public void BarIsDerivedFromOpenGenericFoo() {
        Assert.True(typeof(Bar).IsDerivedFromOpenGenericType(typeof(Foo<>)));
    }
    [Fact]
    public void FooBarIsDerivedFromOpenGenericFoo() {
        Assert.True(typeof(FooBar).IsDerivedFromOpenGenericType(typeof(Foo<>)));
    }
    [Fact]
    public void StringIsNotDerivedFromOpenGenericFoo() {
        Assert.False(typeof(string).IsDerivedFromOpenGenericType(typeof(Foo<>)));
    }
