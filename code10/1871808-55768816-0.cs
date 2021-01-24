lang-c#
builder.Register(
        ctx => {
            var c = ctx.Resolve<IComponentContext>();
            return new AutofacHostedServiceScopeOwner(
                () => c.Resolve<ILifetimeScope>()
                    .BeginLifetimeScope(
                        b => {
                            b.RegisterGeneric(typeof(Logger<>)).As(typeof(ILogger<>));
                            b.Register(
                                    x => new SerilogLoggerFactory(
                                        Log.Logger.ForContext("name", "value")
                                    )
                                )
                                .As<ILoggerFactory>()
                                .InstancePerLifetimeScope();
                        }
                    ),
                scope => new MessageProcessingService(
                    scope.Resolve<ILogger<MessageProcessingService>>()
                )
            );
        }
    )
    .As<IHostedService>();
The reason this works is because in `Program.cs` the logger configuration call `sc.AddLogging(lb => lb.AddSerilog())` registers `ILogger<>` and `ILoggerFactory` as singletons under the covers. The `lb.AddSerilog()` call registers a Serilog provider which is used by the `ILoggerFactory`, but I was not able to find any way to override the provider specifically so I replaced them all.
Hopefully this helps someone.
