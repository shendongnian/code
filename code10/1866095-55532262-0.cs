    private static void SetupEcommerceLogic(IServiceCollection services, bool enabled)
    {
        if (enabled)
        {
            services.AddTransient<IOrderBusinessLogic, OrderBusinessLogic>();
        }
        else
        {
            services.AddTransient<IOrderBusinessLogic, EmptyOrderBusinessLogic>();
        }
    }
