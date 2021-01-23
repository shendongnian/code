    var enumerable = new Mock&lt;IEnumerable&gt;();
    var something = new List&lt;SomeType&gt;
    {
        new SomeType(),
        new SomeType(),
        new SomeType(),
    };
    enumerable.Setup(_ => _.GetEnumerator()).Returns(something.GetEnumerator());
    Assert.That(enumerable.Object.OfType&lt;SomeType&gt;(), Is.EquivalentTo(something));
