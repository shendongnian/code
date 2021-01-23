    public class Cc : Ca
    {
        private Cc()
            : base("Test")
        {
           //We may call protected setter here
        }
    
        private static Ca instance = new Cc();
        public static Ca Instance
        {
            get { return instance; }
        }
    }
    
    public abstract class Ca
    {
        protected Ca(string p1)
        {
            P1 = p1;
        }
        //You may use protected setter and call this setter in descendant constructor
        public string P1
        {
            get;
            private set;
        }
    }
    static void Main(string[] args)
    {
        string s = Cc.Instance.P1; // is not null
    }
