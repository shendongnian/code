         IContainer manager = new Container(r =>
            {
                r.InstanceOf<IHandler>().Is.OfConcreteType<Handler1>().WithName("One");
                r.InstanceOf<IHandler>().Is.OfConcreteType<Handler2>().WithName("Two");
 
                r.ForRequestedType<Processor>().Use<Processor>()
                    .WithCtorArg("name").EqualTo("Jeremy")
                    .TheArrayOf<IHandler>().Contains(x =>
                    {
                        x.TheInstanceNamed("Two");
                        x.TheInstanceNamed("One");
                    });
            });
