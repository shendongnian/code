    public abstract class T { }
    public class TFactory
    {
        public T CreateT() => new TImpl();
        private class TImpl : T { }
    }
