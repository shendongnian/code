    public class NewGenericTypeWithWeirdName
    {
        private readonly static Lazy<main> val = new Lazy<main>(() => new main());
        public static main instance { get { return val.Value; } }
        public int UserID { get; set; }
    }
