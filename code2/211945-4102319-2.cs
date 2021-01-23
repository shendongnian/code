    public class Node : DisplayItem
    {
        public virtual IList<Link> LinksFrom { get; set; }
        public virtual IList<Link> LinksTo { get; set; }
    
        public Node()
        {
            LinksFrom = new List<Link>();
            LinksTo = new List<Link>();
        }
    }
