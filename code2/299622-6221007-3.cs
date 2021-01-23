    [Fact]
    public void ShouldResolveNonBoundValidatorDerivedFromValidatorAsNullValidator()
    {
        var kernel = new StandardKernel();
        kernel.Components.Add<IMissingBindingResolver, MissingValidatorResolver>();
        var validator = kernel.Get<Validator<Article>>();
        Assert.IsType<NullValidator<Article>>(validator);
    }
