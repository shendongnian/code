    public class Tests
    {
        [Fact]
        public void Test()
        {
            var container = new SimpleInjector.Container();
    
            container.Collection.Append<IValidator<IOrder>, OrderValidator>();
            container.Collection.Append<IValidator<Command>, CommandValidator>();
    
            var validators = container.GetAllInstances<IValidator<Command>>();
    
            validators.Should().HaveCount(2);
        }
    }
    
    class OrderValidator : AbstractValidator<IOrder>
    {
    }
    
    class CommandValidator : AbstractValidator<Command>
    {
    }
    
    interface IOrder
    {
    }
    
    class Command : IRequest<CommandResponse>, IOrder
    {
    }
    
    class CommandResponse
    {
    }
