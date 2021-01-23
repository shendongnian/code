    class SharpQuery 
    {
        public IEnumerable<HtmlNode> RepositoryItems { get; set; }
        public IEnumerable<HtmlNode> Find(string selector)
        {
            foreach (var n in this.RepositoryItems)
            {
                // filter the results
                yield return node;
            }
        }
    }
