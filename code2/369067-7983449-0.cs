    Kernel.Bind<UserRepository>.ToConst(YourMockUserRepositoryInstance);
    Kernel.Bind<UserService>.ToConst(YourMockUserServiceInstance);
    Kernel.Bind<BillingRepository>.ToConst(YourMockBillingRepositoryInstance);
    Kernel.Bind<BillingValidation>.ToConst(YourMockBillingValidationInstance);
    Kernel.Bind<BillingService>.ToConst(YourMockBillingServiceInstance);
    Kernel.Bind<AccountingFacade>.ToConst(YourMockAccountingFacadeInstance);
    Kernel.Bind<ApiService>.ToConst(YourMockApiServiceInstance);
    Kernel.Bind<PublicApi>.ToSelf();
    
    var publicApi = Kernel.Get<PublicApi>();
