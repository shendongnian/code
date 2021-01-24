public class Foo {
   [Inject] // or other marker attribute specific to your IoC
   public readonly IMemoryCache;
....
}
2. **Service Locator** - Use a thread safe, singleton reference to your container and resolve the dependency. I'd also avoid this option.
public Foo(): base()
{
  base.MemoryCache = IoC.Resolve<IMemoryCache>();
}
3. **Ctor injection from derived to parent** - Although this might be verbose its actually the right thing to do, as you will be explicit about your contracts and dependencies.
public Foo(IMemoryCache cache): base(cache)
4. **Pass dependency in the method signature** - Very explicit but honours functional programming principles. Eg: Ask yourself is it the whole class which needs that dependency or just one of its methods?
public void Foo(IMemoryCache cache, int bar)
5. **Ctor injection but pass the container to parent if you have too many dependencies**
public Foo(IBar bar, IBaz baz, IContainer container): base(container)
{
  ...
}
I had instances where option 5 worked best during heavy refactorings.
