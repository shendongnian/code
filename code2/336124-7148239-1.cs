    [TestFixture]
    public class BarTest
    {
      [VerifyContract]
      public readonly IContract AccessorTests = new AccessorContract<Bar, Foo>
      {
          Getter = target => target.Foo,
          Setter = (target, value) => target.Foo = value,
          ValidValues = { new Foo(123), new Foo(456), new Foo(789) },
          AcceptNullValue = false,
          DefaultInstance = () => new Bar("Hello"),
          InvalidValues =
          {
              { typeof(ArgumentOutOfRangeException), new Foo(-123), new Foo(-456) },
              { typeof(ArgumentException), new Foo(666) }
          }
      };
    }
