    class Tag
    {
        public Tag(int id, int? parentId, string tag)
        {
            Id = id;
            ParentId = parentId;
            TagName = tag;
        }
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string TagName { get; set; }
    }
    class TagNode
    {
        public Tag Node { get; set; }
        public IList<TagNode> ChildNodes { get; set; }
        public int ChildNodeCount()
        {
            int count = 0;
            if (ChildNodes != null)
            {
                foreach (var node in ChildNodes)
                {
                    count += node.ChildNodeCount();
                }
                count += ChildNodes.Count;
            }
            return count;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var tags = new List<Tag>();
            tags.Add(new Tag(1, null, "Web design"));
            tags.Add(new Tag(2, null, "Programming"));
            tags.Add(new Tag(3, 1, "HTML"));
            tags.Add(new Tag(4, 1, "CSS 3"));
            tags.Add(new Tag(5, 3, "HTML 4"));
            tags.Add(new Tag(6, 3, "HTML 5"));
            IList<TagNode> nodes = tags.Select(y => new TagNode { Node = y, ChildNodes = new List<TagNode>() }).ToList();
            foreach (var node in nodes)
            {
                if (node.Node.ParentId.HasValue)
                    ConnectNodeToParent(nodes, node);
            }
            foreach (var node in nodes)
            {
                Console.WriteLine("Tag id: {0}, Tag name: {1}, Tag count: {2}", node.Node.Id, node.Node.TagName, node.ChildNodeCount());
            }
            Console.ReadLine();
        }
        private static void ConnectNodeToParent(IList<TagNode> nodes, TagNode node)
        {
            var parentNode = nodes.Where(y => y.Node.Id == node.Node.ParentId.Value).Single();
            parentNode.ChildNodes.Add(node);
        }
    }
