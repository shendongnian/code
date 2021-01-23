    public class NodeMap : ClassMap<Node>
    {
        public NodeMap()
        {
            //Id and any other fields mapped in node
            HasMany(x => x.Links);
        }
    }
    public class LinkMap : ClassMap<Link>
    {
        public LinkMap()
        {
            //Id and any other fields mapped in node
            References(x => x.StartNode);
            References(x => x.EndNode);
        }
    }
