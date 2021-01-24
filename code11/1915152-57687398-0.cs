        public class ConcreteA
        {
            public static void Run(IServiceProvider serviceProvider)
            {
                ConcreteB _concreteB = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ConcreteB>();
            }
        }
