    [Test]
    public void ResolvesFooFromContainer()
    {
       var expectedFoo = new Foo();
       var container = MockRepository.GenerateStub<IContainer>();
       container.Stub(c => c.GetInstance<Foo>()).Return(foo);
       var factory = new FooFactory(container);
       
       var createdFoo = factory.CreateFoo();
    
       Assert.That(createdFoo, Is.EqualTo(expectedFoo));
    }
