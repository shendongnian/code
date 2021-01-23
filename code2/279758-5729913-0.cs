    container.Register(AllTypes.FromThisAssembly()
       .BasedOn(typeof(ICommandHandler<>))
       .WithService.Base()
       .Configure(c => c.DependsOn(new{ sendAsync = true })
                        .Lifestyle.Transient));
