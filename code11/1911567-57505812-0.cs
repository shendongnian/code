var containerBuilder = new ContainerBuilder();
containerBuilder.RegisterType<PizzaService>();
containerBuilder.RegisterType<PizzaProducerService>();
containerBuilder.RegisterGeneric(typeof(RepositoryBase<>))
	.As(typeof(IRepositoryBase<>));
var container = containerBuilder.Build();
using (var scope = container.BeginLifetimeScope())
{
	var pizzaService = scope.Resolve<PizzaService>();
	var pizzaProducerService = scope.Resolve<PizzaProducerService>();
}
