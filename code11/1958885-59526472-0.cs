    public class Banana
    {
        private Banana()
        {
            ...
        }
        public static Banana InstantiateBanana()
        {
            Banana banana = new Banana();//<=====How can you instantiate it inside this class? I don't want other assemblies to instantiate it.
            ...
            return banana;
        }
    }
