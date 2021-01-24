    class CommentWalker : CSharpSyntaxWalker
    {
        public CommentWalker(SyntaxWalkerDepth depth = SyntaxWalkerDepth.Node) : base(depth)
        {
        }
        public override void VisitTrivia(SyntaxTrivia trivia)
        {
            if (trivia.IsKind(SyntaxKind.MultiLineCommentTrivia)
                || trivia.IsKind(SyntaxKind.SingleLineCommentTrivia))
            {
                // Do something with the comments
                // For example, find the comment location in the file, so you can replace it later.
                // Make a List as a public property, so you can iterate the list of comments later on.
            }
        }
    }
