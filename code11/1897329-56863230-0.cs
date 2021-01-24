builder.RegisterType<ProcessSalaryRequest>().As<IProcess<ProcessSalaryRequest>>().SingleInstance();
builder.RegisterType<ProcessLeavesRequest>().As<IProcess<ProcessLeavesRequest>>().SingleInstance();
Then, you should resolve using the interface provided in the "As" section like this:
builder.Register(c => new ProcessFactory(c.Resolve<IProcess<ProcessSalaryRequest>>(),c.Resolve<IProcess<ProcessLeavesRequest>>())).As<IProcessFactory>().SingleInstance();
In IoC libraries (or most of them) you resolve a type by the specific Interface/BaseType registered "as" reference.
