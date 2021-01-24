public void Install(IWindsorContainer container, IConfigurationStore store)
{
    container.Register(Component.For<ISomeClass>().ImplementedBy<SomeClass>());
    container.Register(Component.For<IDependency1>().ImplementedBy<Dependency1>());
    container.Register(
        Component.For<ISomeSimpleDepencency>().ImplementedBy<ISomeSimpleDepencency>().LifeStyleScoped(),
        Component.For<ISomeSimpleDepencencyFactory().AsFactory());
}
And in the invoking method
public void WebServiceMethod(string runtimeArgument)
{
    using (container.BeginScope())
    {
        IDependency3 dependency3= container.Resolve<ISomeSimpleDepencencyFactory>().Create(runtimeArgument);
        
        ISomeClass someClass = container.Resolve<ISomeClass>());
    }
}
The instance using the run time parameter will be retained in the scope.
I'm not marking this as the answer because I'm not yet convinced that there isn't a better solution
  [1]: https://github.com/castleproject/Windsor/blob/master/docs/lifestyles.md
