    public class Member
    {
        public string KindText { get; set; }
        public MemberToken NameToken { get; set; }
        public MemberToken TypeToken { get; set; }
        public MemberToken DeclarationToken { get; set; }
        public override string ToString() => $"Name: {this.NameToken}, Type: {this.TypeToken}, Declaration: {this.DeclarationToken}";
    }
    public class MemberToken
    {
        public string Name { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public MemberToken(string code, TextSpan span)
        {
            this.Name = code.Substring(span.Start, span.Length);
            this.Start = span.Start;
            this.Length = span.Length;
        }
        public override string ToString() => $"{this.Name} ({this.Start}, {this.Length})";
    }
