    usign system.runtime.serialization
    
    [datacontract]
    public class Tree
    {
        public Tree()
        {
            ChildrenNodes = new List<TreeStructure>();
        }
        [datamember]
        public List<Tree> ChildrenNodes { get; set; }
        [datamember]
        public int Id { get; set; }
        [datamember]
        public string Content {get; set;}
    }
    
    void serialize(Tree tree,string filename)
    {
    datacontractserializer serializer = new datacontracetserializer (typeof(Tree));
    system.xml.xmltextwriter writer = new xmltextwriter(filename,Encoding.UTF32);
    serializer.WriteObject(writer,tree);
    writer.close();
    }
    
    void deserialize(ref Tree tree,string filename)
    {
        xmltextreader reader = new xmltextreader*new streamreader(filename, Encoding.UTF32));
    DataContracetSerializer deser = new datacontracetserializer(typeof(Tree));
    trr = (Tree)deserializer.readObject(reader);
    reader.close()
    }
