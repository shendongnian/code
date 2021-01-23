    public class SingletonBasher : Singleton
    {
    }
    Singleton x = Singleton.Instance();
    Singleton y = new SingletonBasher();
