    public class MemberOfMyType
    {
        public bool UnimportantMember1 { get; set; }
        public int UnimportantMember2 { get; set; }
        public string TheImportantString { get; set; }
    }
    public class GoodClass
    {
        public MemberOfMyType MemberOfMyType { get; set; }
        public string SomeOtherMemberOfClass { get; set; }
    }
