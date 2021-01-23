            // Load
            var settings = new BarSettings();
            var expectedProcessorType = typeof(BarProcessor);
            // Register
            var constructorFinder = new AcceptsTypeConstructorFinder(settings.GetType());
            var builder = new ContainerBuilder();
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterInstance(settings);
            builder.RegisterAssemblyTypes(assembly)
                   .Where(type => type.IsAssignableTo<IProcessor>() && constructorFinder.FindConstructors(type).Any())
                   .As<IProcessor>();
            builder.RegisterAssemblyTypes(assembly)
                   .As<IProcessorConsumer>();
            using (var container = builder.Build())
            {
                // Resolve
                var processorConsumer = container.Resolve<IProcessorConsumer>();
                Assert.IsInstanceOfType(processorConsumer, typeof(ProcessorConsumer));
                Assert.IsInstanceOfType(processorConsumer.Processor, expectedProcessorType);
                // Run
                // TODO
            }
