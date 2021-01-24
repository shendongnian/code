    public sealed class MissPiggy
    {
        private static Lazy<MissPiggy> _instance = new Lazy<MissPiggy>(() => new MissPiggy());
        private MissPiggy()
        {
        }
        public static MissPiggy Instance
        {
            get { return _instance.Value; }
        }
    }
