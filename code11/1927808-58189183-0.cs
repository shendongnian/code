    private class MyHandler : GraphHandler
    {
        private readonly IUriNode _rdfsSubClassOf;
        private readonly IUriNode _rdfsLabel;
        public MyHandler(IGraph g)
            : base(g)
        {
            _rdfsSubClassOf = g.CreateUriNode(UriFactory.Create("http://www.w3.org/2000/01/rdf-schema#subClassOf"));
            _rdfsLabel = g.CreateUriNode(UriFactory.Create("http://www.w3.org/2000/01/rdf-schema#label"));
        }
        protected override bool HandleTripleInternal(Triple t)
        {
            if (t.Predicate is UriNode uri
                && !uri.Equals(_rdfsSubClassOf)
                && !uri.Equals(_rdfsLabel))
            {
                return true;
            }
            else if (t.Object is LiteralNode l && l.Language == "zh")
            {
                return true;
            }
            return base.HandleTripleInternal(t);
        }
    }
