    static class Program
    {
        public static void Main()
        {
    
            Node node = new Node { Data = "parent" };
            node.AddChild(new Node { Data = "child" });
            using (MemoryStream memStream = new MemoryStream())
            {
                Serializer.Serialize(memStream, new NodeWrapper { Root = node });
                memStream.Position = 0;
                Node deserialized = Serializer.Deserialize<NodeWrapper>(memStream).Root;
    
                Link childLink = deserialized.ChildLinks.Single();
                Debug.Assert(ReferenceEquals(childLink, childLink.Child.ParentLinks.Single()));
            }
        }
    }
    [ProtoContract]
    class NodeWrapper
    {
        [ProtoMember(1, AsReference = true, IsRequired = true)]
        public Node Root {get;set;}
    }
