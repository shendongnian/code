public enum RepoType
{
	Raven,
	Mongo
}
...
builder.RegisterType<RavenUserRepository>().Keyed<IUserRepository>(RepoType.Raven).InstancePerLifetimeScope();
builder.RegisterType<MongoUserRepostiory>().Keyed<IUserRepository>(RepoType.Mongo).InstancePerLifetimeScope();
and instead of 
builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(Consumers.IMessageConsumer<>))).AsClosedTypesOf(typeof(Consumers.IMessageConsumer<>));
we have
builder.RegisterGeneric(typeof(MessageConsumer<>))
	.Keyed(RepoType.Mongo, typeof(IMessageConsumer<>)).WithParameter(
		new ResolvedParameter(
			(pi, ctx) => pi.ParameterType == typeof(IUserRepository),
			(pi, ctx) => ctx.ResolveKeyed<IUserRepository>(RepoType.Mongo)));
builder.RegisterGeneric(typeof(MessageConsumer<>))
	.Keyed(RepoType.Raven, typeof(IMessageConsumer<>))
	.WithParameter(
		new ResolvedParameter(
			(pi, ctx) => pi.ParameterType == typeof(IUserRepository),
			(pi, ctx) => ctx.ResolveKeyed<IUserRepository>(RepoType.Raven)));
That last part isn't the prettiest but for each repo it's basically saying "register an `IConsumer<>` with a key, which internally resolves using an `IUserRepository` with the same key". We can then just resolve `IConsumer<>`s as required from the consuming code, either as an `IEnumerable<>` (this is automatically available from Autofac if you have multiple registrations for a service) or individually with our key:
var consumers = scope.Resolve<IEnumerable<IMessageConsumer<T>>>();
foreach (var messageConsumer in consumers)
{
	messageConsumer.Handle(message, CancellationToken.None);
}
or
var mongoConsumer = scope.ResolveKeyed<IMessageConsumer<T>>(RepoType.Mongo);
mongoConsumer.Handle(message, CancellationToken.None);
var ravenConsumer = scope.ResolveKeyed<IMessageConsumer<T>>(RepoType.Raven);
ravenConsumer.Handle(message, CancellationToken.None);
