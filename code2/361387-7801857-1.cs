    [Test]
    public void ThrowIfNone_ThrowsTheSpecifiedException_GivenNoSuccessfulTryGet()
    {
        Assert.That(() =>
            Maybe<double>.None
                .TryGet(() => { throw new Exception(); })
                .TryGet(() => { throw new Exception(); })
                .TryGet(() => { throw new Exception(); })
                .ThrowIfNone(() => new NoCalcsWorkedException())
                .Value,
            Throws.TypeOf<NoCalcsWorkedException>());
    }
    [Test]
    public void Value_ReturnsTheValueOfTheFirstSuccessfulTryGet()
    {
        Assert.That(
            Maybe<double>.None
                .TryGet(() => { throw new Exception(); })
                .TryGet(() => 0)
                .TryGet(() => 1)
                .ThrowIfNone(() => new NoCalcsWorkedException())
                .Value,
            Is.EqualTo(0));
    }
