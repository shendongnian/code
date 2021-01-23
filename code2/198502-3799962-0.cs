    class SharpQuery : IEnumerable<HtmlNode>
    {
        public IEnumerable<HtmlNode> Find(string selector)
        {
            foreach (var n in this)
            {
                // filter the results
                yield return node;
            }
        }
    }
