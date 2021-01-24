    public class MemberCollector : CSharpSyntaxWalker
    { 
        public List<FieldDeclarationSyntax> Fields { get; } = new List<FieldDeclarationSyntax>();
        public List<PropertyDeclarationSyntax> Properties { get; } = new List<PropertyDeclarationSyntax>();
        public List<LocalDeclarationStatementSyntax> Variables { get; } = new List<LocalDeclarationStatementSyntax>();
        public override void VisitFieldDeclaration(FieldDeclarationSyntax node) => this.Fields.Add(node);
        public override void VisitPropertyDeclaration(PropertyDeclarationSyntax node) => this.Properties.Add(node);
        public override void VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node) => this.Variables.Add(node);
    }
