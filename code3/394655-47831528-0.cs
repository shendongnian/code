     public class CustomWalker : CSharpSyntaxWalker
    {
        static int Tabs = 0;
        public override void Visit(SyntaxNode node)
        {
            Tabs++;
            var indents = new String('\t', Tabs);
            Console.WriteLine(indents + node.Kind());
            base.Visit(node);
            Tabs--;
        }
    }
    
    static void Main(string[] args)
    {
        var tree = CSharpSyntaxTree.ParseText(@"
            public class MyClass
            {
                public void MyMethod()
                {
                }
                public void MyMethod(int n)
                {
                }
           ");
        
        var walker = new CustomWalker();
        walker.Visit(tree.GetRoot());
    }
