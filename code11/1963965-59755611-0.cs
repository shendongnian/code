    public class DataClass
    {
        public int num { get; set; }
        public string code { get; set; }
        private PartClass _part;
        public PartClass part { get { if (_part == null) _part = new PartClass(); return _part; } set { _part = value; } }
        private MemberClass _member;
        public MemberClass member { get { if (_member == null) _member = new MemberClass(); return _member; } set { _member = value; } }
    }
