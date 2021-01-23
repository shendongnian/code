    class GenericFoo<T> { }
    class DerivedGenericFoo<T> : GenericFoo<T> { }
    class Foo : GenericFoo<int> { }
    class Bar : Foo { }
    class Animal { }
    [Fact]
    public void DerivedGenericFoo_derives_from_open_GenericFoo() {
        Assert.Equal(
            true,
            IsDerivedFrom(
                typeof(DerivedGenericFoo<int>),
                typeof(GenericFoo<>)
            )
        );
    }
    [Fact]
    public void Foo_derives_from_open_GenericFoo() {
        Assert.Equal(true, IsDerivedFrom(typeof(Foo), typeof(GenericFoo<>)));
    }
    [Fact]
    public void Bar_derives_from_open_GenericFoo() {
        Assert.Equal(true, IsDerivedFrom(typeof(Bar), typeof(GenericFoo<>)));
    }
    [Fact]
    public void Animal_does_not_derive_from_open_GenericFoo() {
        Assert.Equal(false, IsDerivedFrom(typeof(Animal), typeof(GenericFoo<>)));
    }
