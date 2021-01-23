    [Fact]
    public void DecimalsShouldReallyBeAssignableFromInts()
    {
        var d = default(decimal);
        var i = default(i);
        Assert.Throws<InvalidCastException)( () => (int)d);
        Assert.DoesNotThrow( () => (decimal)i);
    }
