	var programText =
	@"public class Callee
    {
        private bool _visited = false;
        public void DoSomethingElse()
        {
            _visited = false;
        }
    }";
	var tree = CSharpSyntaxTree.ParseText(programText);
	var root = tree.GetRoot();
	var visitor = new AssignmentReplacer();
	var updated = visitor.Visit(root);
