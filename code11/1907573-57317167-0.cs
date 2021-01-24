    //Arrange
    var foobar = MockRepository.GenerateStub<IFooBar>();
    foobar.Stub(_ => _.Foo(Arg<string>.Is.Anything))
      .Repeat.Any()
      .Do((Func<string, string>)(input => {
          if (input == "string1") {
              return "result1";
          } else if (input == "string2") {
              return "result2";
          }
          return string.Empty; // or some other arbitrary string
      }));
    //Act & Assert to prove it works (using FluentAssertions)
    foobar.Foo("string1").Should().Be("result1");
    foobar.Foo("string2").Should().Be("result2");
    foobar.Foo(null).Should().Be(string.Empty); // or some other arbitrary string
