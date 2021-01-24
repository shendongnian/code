	var programText =
	@"public class Callee
    {
        private bool _visited = 0;
        public void DoSomethingElse()
        {
            _visited = false;
        }
    }";
	var tree = CSharpSyntaxTree.ParseText(programText);
	var root = tree.GetRoot();
	var visitor = new AssignmentReplacer();
	var updated = visitor.Visit(root);
