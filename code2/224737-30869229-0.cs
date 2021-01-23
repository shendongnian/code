    public static class ITreeExtensions
    {
        public static string ToStringTree(this ITree tree, Parser parser)
        {
            var rule = _tree as RuleContext;
            if (rule != null)
            {
                return rule.ToStringTree(_parser);
            }
            var terminalNode = _tree as TerminalNodeImpl;
            if (terminalNode != null)
            {
                return terminalNode.ToStringTree(_parser);
            }
            return _tree.ToStringTree();
        }
    }
