    var application = new MsOl.Application();
    MsOl.NameSpace ns = application.GetNamespace("MAPI");
    Stores stores = ns.Stores;
    foreach (var store in AppSession.Stores
        .Cast<MsOl.Store>()
        .Where(c => c.ExchangeStoreType == MsOl.OlExchangeStoreType.olExchangeMailbox))
    {
        ...
    }
