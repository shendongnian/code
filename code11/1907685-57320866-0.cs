    var lang = "english";
    IUnityContainer container = new UnityContainer();
    container.RegisterType<IAlphabet, English>("english");
    container.RegisterType<IAlphabet, Russian>("russian");
    
    IAlphabet rus = container.Resolve<IAlphabet>();  // returns the Russian object
    IAlphabet eng = container.Resolve<IAlphabet>(lang); // returns the English object
