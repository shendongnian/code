    [TestFixture]
    public class AbstractFixtureBase
    {
        ...
    }
    
    [TestFixture(typeof(string))]
    public class DerivedFixture<T> : AbstractFixtureBase
    {
        ...
    }
