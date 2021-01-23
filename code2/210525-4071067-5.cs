    [Test]
    public void mock_an_abstract_class_with_generic()
    {
        var mocks = new MockRepository();
        var baseAbstract = mocks.StrictMock<BaseAbstract>();
        var abstractClass = mocks.PartialMock<AbstractClass<BaseAbstract>>();
        using (mocks.Record())
        {
            baseAbstract.Stub(a => a.Increment()).Return(5);
            abstractClass.Stub(a => a.Abstract()).Return(baseAbstract);
        }
        using (mocks.Playback())
        {
            abstractClass.Concrete().ShouldEqual(5);
            abstractClass.Concrete().ShouldEqual(10);
        }
    }
