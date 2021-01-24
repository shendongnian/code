c#
public class Foo
{
    public IEnumerable<INamed> GetNames()
    {
        return new[] {
            new ComplexEntity() { Id = 1, Name = "NAM1", Domain = "DOM1" },
            new ComplexEntity() { Id = 2, Name = "NAM2", Domain = "DOM2" }
        };
    }
}
The following xUnit + ExpectedObjects test will pass:
c#
using ConsoleProject;
using ExpectedObjects;
using Xunit;
namespace ConsoleProject_Tests
{
    public class ExpectedObjectsTests
    {
        [Fact]
        public void GetNames_should_return_INamed_ExpectedObjects_Style()
        {
            var expected = new[]
            {
                new { Name = "NAM1" },
                new { Name = "NAM2" }
            }.ToExpectedObject();
            var systemUnderTest = new Foo();
            var actual = systemUnderTest.GetNames();
            expected.ShouldMatch(actual);
        }
    }
}
Note that `ToExpectedObject()` is being fed anonymous objects, not concrete classes.
Now compare that with the old way of doing things by implementing a custom `IEqualityComparer<INamed>` which just happens to be on the test class...
c#
using ConsoleProject;
using System;
using System.Collections.Generic;
using Xunit;
namespace ConsoleProject_Tests
{
    public class ClassicXUnitTests : IEqualityComparer<INamed>
    {
        bool IEqualityComparer<INamed>.Equals(INamed x, INamed y)
        {
            if (x == null && y == null) return true;
            if (x == null || y == null) return false;
            return String.Equals(x.Name, y.Name);
        }
        int IEqualityComparer<INamed>.GetHashCode(INamed obj)
        {
            return obj.Name.GetHashCode();
        }
        [Fact]
        public void GetNames_should_return_INamed_xUnit_Style()
        {
            var expected = new[]
            {
                new SimpleEntity() { Name = "NAM1" },
                new SimpleEntity() { Name = "NAM2" }
            };
            var systemUnderTest = new Foo();
            var actual = systemUnderTest.GetNames();
            Assert.Equal<INamed>(expected, actual, this);
        }
    }
}
It still needs a concrete class that implements `INamed` because you can't just create a new abstract class or interface.
