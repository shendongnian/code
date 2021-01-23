    int i = 0;
    foreach (Type type in this.GetType().Assembly.GetTypes())
    {
            if (formaterInterface.IsAssignableFrom(type) && !type.Equals(formaterInterface))
            {
                    container.Register(Component.For<IFormater().ImplementedBy(type).Named(i.ToString()));
                    formatters.Add(container.Resolve<IFormater>(i.ToString()));
                    i++;
            }
    }
