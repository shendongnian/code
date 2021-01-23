    [Test]
    [ExpectedException(typeof(ArgumentNullException))]
    public void EmptyNameInConstructorThrowsExceptionTest()
    {
        SomeClass someClass = new SomeClass(null);
        Assert.Fail("Exception not thrown");
    }
