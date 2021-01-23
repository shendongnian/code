    interface ICommand { }
    
    class FooCommand : ICommand { }
    
    class SpecialFooCommand : FooCommand { }
    
    interface ICommandHandler<in T> where T : ICommand
    {
        void Handle(T command);
    }
    
    class FooCommandHandler : ICommandHandler<FooCommand>
    {
        public void Handle(FooCommand command)
        {
            // ...
        }
    }
    var builder = new ContainerBuilder();
    builder.RegisterType<FooCommandHandler>()
           .As<ICommandHandler<SpecialFooCommand>>()
           .As<ICommandHandler<FooCommand>>();
    var container = builder.Build();
    var fooCommand = new FooCommand();
    var specialCommand = new SpecialFooCommand();
    container.Resolve<ICommandHandler<FooCommand>>().Handle(fooCommand);
    container.Resolve<ICommandHandler<FooCommand>>().Handle(specialCommand);
    container.Resolve<ICommandHandler<SpecialFooCommand>>().Handle(specialCommand);
