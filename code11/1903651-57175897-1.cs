builder.RegisterType<BarChannel>()
    .InstancePerMatchingLifetimeScope(new TypedService(typeof(FooCall)),new TypedService(typeof(AnotherUnitOfWork))); 
 
To wrap this up a bit more neatly you could use:
private static IEnumerable<Type> GetTypesImplementingInterface<TInterface>()
{
    return AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(s => s.GetTypes())
        .Where(p => typeof(TInterface).IsAssignableFrom(p));
}
and then a new extension method:
public static class AutofacRegistrationBuilderExtensions
{
    public static IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> InstancePerOwned<TLimit, TActivatorData, TRegistrationStyle>(
        this IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> builder, IEnumerable<Type> serviceTypes)
    {
        return builder.InstancePerMatchingLifetimeScope(serviceTypes.Select(s => new TypedService(s)).ToArray());
    }
}
The usage would then just be:
builder.RegisterType<BarChannel>().InstancePerOwned(GetTypesImplementingInterface<IUnitOfWork>());
I'm not sure if the last part there would be worth pulling into Autofac itself, but I guess if it did then it might be better to combine the two methods above together and retrieve the list of types applicable from existing registrations, e.g. something like
InstancePerOwnedImplementing<TInterface>();
Alternatively, it would probably be a bit messy to extend the matching scope logic to check the relationship between types at resolution time, since not all tags are of the type Type.
