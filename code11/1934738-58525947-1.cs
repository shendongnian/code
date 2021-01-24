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
