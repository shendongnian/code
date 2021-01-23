    using HtmlAgilityPack;
    internal static class HtmlAgilityPackExtensions
    {
        public static void RemoveNodeKeepChildren(this HtmlNode node)
        {
            foreach (var child in node.ChildNodes)
            {
                node.ParentNode.InsertBefore(child, node);
            }
            node.Remove();
        }
    }
