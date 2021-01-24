    public static class RegistrationExtension
    {
        public static IRegistrationBuilder<TPage, ConcreteReflectionActivatorData, SingleRegistrationStyle> 
            RegisterPage<TPage, TViewModel>(this ContainerBuilder builder)
            where TPage : IPage
        {
            return builder.RegisterType<TPage>()
                          .OnActivated(e =>
                          {
                              e.Instance.DataContext = e.Context.Resolve<TViewModel>();
                          });
        }
    }
