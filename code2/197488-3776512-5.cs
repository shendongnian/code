    readonly Selectors _selectors = new Selectors();
    public class Selectors
    {
        public string[] Order = { "ID", "NAME", "TAG" };
        public Match Match = new Match();
        public class Match
        {
            public Regex ID = new Regex(@"#((?:[\w\u00c0-\uFFFF-]|\\.)+)");
            public Regex CLASS = new Regex(@"\.((?:[\w\u00c0-\uFFFF-]|\\.)+)");
            public Regex NAME = new Regex(@"\[name=['""]*((?:[\w\u00c0-\uFFFF-]|\\.)+)['""]*\]");
            public Regex ATTR = new Regex(@"\[\s*((?:[\w\u00c0-\uFFFF-]|\\.)+)\s*(?:(\S?=)\s*(['""]*)(.*?)\3|)\s*\]");
            public Regex TAG = new Regex(@"^((?:[\w\u00c0-\uFFFF\*-]|\\.)+)");
            public Regex CHILD = new Regex(@":(only|nth|last|first)-child(?:\((even|odd|[\dn+-]*)\))?");
            public Regex POS = new Regex(@":(nth|eq|gt|lt|first|last|even|odd)(?:\((\d*)\))?(?=[^-]|$)");
            public Regex PSEUDO = new Regex(@":((?:[\w\u00c0-\uFFFF-]|\\.)+)(?:\((['""]?)((?:\([^\)]+\)|[^\(\)]*)+)\2\))?");
        }
        public object LeftMatch = new object();
        public AttrMap AttrMap = new AttrMap();
        public class AttrMap
        {
            public string Class = "className";
            public string For = "htmlFor";
        }
    }
