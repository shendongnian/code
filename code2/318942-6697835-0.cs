    public class Language
    {
        public static readonly UnSpecified = new Laguage();
        protected Language()
        {  }
    }
    
    public class Asian : Language
    {
        public static readonly Language Cantonese = new Asian();
        public static readonly Language Mandarin = new Asian();
        protected Asian() : base()
        { }
    }
    public class European : Language
    {
        public static readonly Language Italian = new European();
        public static readonly Language German = new European();
        protected European() : base()
        { }
    }
