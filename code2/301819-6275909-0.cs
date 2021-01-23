    // new interface just for A
    public interface ICforA : IC { }
    // new interface just for B
    public interface ICforB : IC { }
    container = new UnityContainer()
               .RegisterType<IA, A>()
               .RegisterType<IB, B>()
               .RegisterType<ICforA, C>(new InjectionConstructor(strA));
               .RegisterType<ICforB, C>(new InjectionConstructor(strB));
