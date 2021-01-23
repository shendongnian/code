    public ViewModel(IUnityContainer container) 
    {
        IQuoteSource model1 = container.Resolve<IQuoteSource>();
        ... etc ...
    }
