    public class MemberCollector : CSharpSyntaxWalker
    { 
        public List<FieldDeclarationSyntax> Fields { get; } = new List<FieldDeclarationSyntax>();
        public List<PropertyDeclarationSyntax> Properties { get; } = new List<PropertyDeclarationSyntax>();
        public override void VisitFieldDeclaration(FieldDeclarationSyntax node) => this.Fields.Add(node);
        public override void VisitPropertyDeclaration(PropertyDeclarationSyntax node) => this.Properties.Add(node);
    }
