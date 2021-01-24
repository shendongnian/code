    public class ClassParser
    {
        public string Code { get; set; }
        public SyntaxNode Root { get; set; }
        public ClassParser(string code)
        {
            this.Code = code;
            var tree = CSharpSyntaxTree.ParseText(code);
            this.Root = tree.GetCompilationUnitRoot();
        }
        public List<Member> GetMembers()
        {
            var collector = new MemberCollector();
            collector.Visit(this.Root);
            var results = new List<Member>();
            results.AddRange(collector.Properties.Select(p => new Member()
            {
                KindText = p.Kind().ToString(),
                DeclarationToken = new MemberToken(this.Code, p.Span),
                NameToken = new MemberToken(this.Code, p.Identifier.Span),
                TypeToken = new MemberToken(this.Code, p.Type.Span),
            }));
            results.AddRange(collector.Fields.SelectMany(f => f.Declaration.Variables.Select(v => new Member()
            {
                KindText = f.Kind().ToString(),
                DeclarationToken = new MemberToken(this.Code, f.Span),
                TypeToken = new MemberToken(this.Code, f.Declaration.Type.Span),
                NameToken = new MemberToken(this.Code, v.Span),
            })));
            results.AddRange(collector.Variables.SelectMany(f => f.Declaration.Variables.Select(v => new Member()
            {
                KindText = f.Kind().ToString(),
                DeclarationToken = new MemberToken(this.Code, f.Span),
                TypeToken = new MemberToken(this.Code, f.Declaration.Type.Span),
                NameToken = new MemberToken(this.Code, v.Span),
            })));
            return results;
        }
    }
