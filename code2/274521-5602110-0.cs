    Bind<IEngine>.To<GasEngine>();
    Bind<ICar>.To<Sedan>();
    class Sedan : ICar
    {
        public Sedan(IEngine engine) { }
    }
    // ...
    kernel.Get<ICar>(); // get me a new car
