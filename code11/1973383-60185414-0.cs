    public static void RegisterTypes(IUnityContainer container)
    {
        container.RegisterType<ISearchable, CityReader>("City");
        container.RegisterType<ISearchable, LandlordReader>("Landlord");
    }
    public LandlordController([Dependency("Landlord")]ISearchable searcher)
    {
        this.searcher = searcher;
    }
