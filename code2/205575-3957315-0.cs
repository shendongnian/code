    [Test, ExpectedException("Your.Namespace.TestCustomException")]
    public void FirstOnEmptyEnumerable()
    {
        throw new Exception(); // with this, the test should fail, but it doesn't
        this.emptyEnumerable.First(new TestCustomException());
    }
